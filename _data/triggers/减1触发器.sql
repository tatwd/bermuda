-- ȡ����ע
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

--��notice_trace����ɾ��һ������ʱ����notice��trace_count�ֶ��Զ���1
create trigger delete_notice_trace on notice_trace
for delete
as 
begin 
   update notice set trace_count -= 1
   from notice, deleted
   where notice.id = deleted.notice_id
end

go

--��notice_cmnt����ɾ��һ������ʱ����notice��cmnt_count�ֶ��Զ���1
create trigger delete_notice_cmnt on notice_cmnt
for delete
as 
begin 
   update notice set cmnt_count -= 1
   from notice, deleted
   where notice.id = deleted.notice_id
end

go

-- �� BmdCurrent ����ɾ��һ������ʱ���� BmdTopicJoin �Զ�ɾ����Ӧ CurrentId �ļ�¼
create trigger DeleteBmdCurrent on BmdCurrent
for delete
as 
begin 
   delete BmdTopicJoin from BmdTopicJoin, deleted
   where BmdTopicJoin.CurrentId = deleted.Id
end

go

-- �� BmdTopicJoin ����ɾ��һ������ʱ���� BmdTopic �� JoinCount �ֶ��Զ��� 1
create trigger DeleteBmdTopicJoin on BmdTopicJoin
for delete
as 
begin 
   update BmdTopic set JoinCount -= 1
   from BmdTopic, deleted
   where BmdTopic.id = deleted.TopicId
end

go

--��notice����ɾ��һ������ʱspecies����notice_count�ֶ��Զ���1
create trigger delete_notice on notice
for delete
as 
begin 
   update species set notice_count -= 1
   from species, deleted 
   where species.img = deleted.img
end

go

--��goods_cmnt����ɾ��һ������ʱ����goods��cmnt_count�ֶ��Զ���1
create trigger delete_goods_cmnt on goods_cmnt
for delete
as 
begin 
   update goods set cmnt_count -= 1
   from goods, deleted
   where goods.id = deleted.goods_id
end

go

--��current_cmnt����ɾ��һ������ʱ����current��cmnt_count�ֶ��Զ���1
create trigger delete_current_cmnt on current_cmnt
for delete
as 
begin 
   update [current] set [current].cmnt_count -= 1
   from [current], deleted
   where [current].id = deleted.current_id
end

go

--��current_star����ɾ��һ������ʱ����current��star_count�ֶ��Զ���1
create trigger delete_current_star on current_star
for delete
as 
begin 
   update [current] set [current].star_count += 1
   from [current], deleted
   where [current].id = deleted.current_id
end

go
