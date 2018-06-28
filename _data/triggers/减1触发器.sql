-- 取消关注
create trigger DeleteBmdUserFollow on BmdUserFollow
for delete
as 
begin 
   update BmdUser set FollowingCount -= 1
   from BmdUser, deleted
   where BmdUser.Id = deleted.UserId

   update BmdUser set FollowerCount -= 1
   from BmdUser, deleted
   where BmdUser.Id = deleted.FollowingId
end

go

--在notice_trace表中删除一个数据时主表notice中trace_count字段自动减1
create trigger delete_notice_trace on notice_trace
for delete
as 
begin 
   update notice set trace_count -= 1
   from notice, deleted
   where notice.id = deleted.notice_id
end

go

--在notice_cmnt表中删除一个数据时主表notice中cmnt_count字段自动减1
create trigger delete_notice_cmnt on notice_cmnt
for delete
as 
begin 
   update notice set cmnt_count -= 1
   from notice, deleted
   where notice.id = deleted.notice_id
end

go

-- 在 BmdCurrent 表中删除一个数据时主表 BmdTopicJoin 自动删除对应 CurrentId 的记录
create trigger DeleteBmdCurrent on BmdCurrent
for delete
as 
begin 
   delete BmdTopicJoin from BmdTopicJoin, deleted
   where BmdTopicJoin.CurrentId = deleted.Id
end

go

-- 在 BmdTopicJoin 表中删除一个数据时主表 BmdTopic 中 JoinCount 字段自动加 1
create trigger DeleteBmdTopicJoin on BmdTopicJoin
for delete
as 
begin 
   update BmdTopic set JoinCount -= 1
   from BmdTopic, deleted
   where BmdTopic.id = deleted.TopicId
end

go

--在notice表中删除一个数据时species表中notice_count字段自动减1
create trigger delete_notice on notice
for delete
as 
begin 
   update species set notice_count -= 1
   from species, deleted 
   where species.img = deleted.img
end

go

--在goods_cmnt表中删除一个数据时主表goods中cmnt_count字段自动减1
create trigger delete_goods_cmnt on goods_cmnt
for delete
as 
begin 
   update goods set cmnt_count -= 1
   from goods, deleted
   where goods.id = deleted.goods_id
end

go

--在current_cmnt表中删除一个数据时主表current中cmnt_count字段自动减1
create trigger delete_current_cmnt on current_cmnt
for delete
as 
begin 
   update [current] set [current].cmnt_count -= 1
   from [current], deleted
   where [current].id = deleted.current_id
end

go

--在current_star表中删除一个数据时主表current中star_count字段自动减1
create trigger delete_current_star on current_star
for delete
as 
begin 
   update [current] set [current].star_count += 1
   from [current], deleted
   where [current].id = deleted.current_id
end

go
