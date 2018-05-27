using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using Version = Lucene.Net.Util.Version;

namespace Bermuda.Common
{
    public class SearchUtil
    {
        private static Directory directory;

        //private static Directory LoadDirectory()
        //{
        //    System.Configuration.ConfigurationManager.AppSettings[""]
        //}

        public static void LoadFSDirectory(string path)
        {
            directory = FSDirectory.Open(path);
        }

        public static void LoadRAMDDirectory()
        {
            directory = new RAMDirectory();
        }

        public static void CreateIndex<T>(IEnumerable<T> entities) where T : class, new()
        {
            // 是否更新索引
            var isUpdate = true;

            // 判断索引是否存在
            if (IndexReader.IndexExists(directory))
            {
                if (IndexWriter.IsLocked(directory))
                    IndexWriter.Unlock(directory);
            }

            using (Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30))
            using (IndexWriter indexWriter = new IndexWriter(directory, analyzer, isUpdate,
                IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // get props
                var props = typeof(T).GetProperties();

                foreach (var entity in entities)
                {
                    Document doc = new Document();
                    IList<string> values = new List<string>();

                    foreach (var prop in props)
                    {
                        var isAnalyzed = !prop.Name.ToLower().Contains("id")
                            ? Field.Index.ANALYZED
                            : Field.Index.NOT_ANALYZED;
                        var value = prop.GetValue(entity)?.ToString() ?? null;

                        doc.Add(new Field(prop.Name,
                            value,
                            Field.Store.YES,
                            isAnalyzed));

                        values.Add(value);
                    }

                    var fullText = String.Join("|", values);
                    doc.Add(new Field("FullText",
                        fullText,
                        Field.Store.YES,
                        Field.Index.ANALYZED));

                    indexWriter.AddDocument(doc);
                }

                indexWriter.Optimize();
                indexWriter.Flush(true, true, true);
            }
        }

        public static IList<T> Search<T>(string fieldName, string searchText, int pageSize) where T : class, new()
        {
            IList<T> result = new List<T>();
            var props = typeof(T).GetProperties();

            using (IndexReader reader = IndexReader.Open(directory, true))
            using (IndexSearcher searcher = new IndexSearcher(reader))
            {
                using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
                {
                    QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, fieldName, analyzer);

                    // support `*xxx`
                    parser.AllowLeadingWildcard = true;

                    Query query = parser.Parse(searchText);
                    ScoreDoc[] scoreDocs = searcher.Search(query, pageSize).ScoreDocs;

                    foreach (var score in scoreDocs)
                    {
                        Document doc = searcher.Doc(score.Doc);
                        T t = new T();

                        foreach (var prop in props)
                        {
                            var value = Convert.ChangeType(doc.Get(prop.Name), prop.PropertyType);
                            prop.SetValue(t, value);
                        }

                        result.Add(t);
                    }
                }
            }

            directory.Dispose();
            return result;
        }

        public static IList<T> SearchFullText<T>(string searchText, int pageSize) where T : class, new()
        {
            return Search<T>("FullText", searchText, pageSize);
        }
    }
}
