create trigger insert_notice on notice
for insert
as
begin 
  update notice
  set notice.status = 'δ�һ�'
  from notice, inserted
  where notice.id = inserted.id
    and notice.type like 'Ѱ��%'

  update notice
  set notice.status = 'δ���'
  from notice, inserted
  where notice.id = inserted.id
    and notice.type like '����%'
end