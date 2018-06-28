--�� notice_trace ���в���һ������ʱ���� notice �� trace_count �ֶ��Զ���1
create trigger insert_notice_trace on notice_trace
for insert
as 
begin 
   update notice set trace_count += 1
   from notice, inserted
   where notice.id = inserted.notice_id
end

go

--�� notice_cmnt ���в���һ������ʱ���� notice �� cmnt_count �ֶ��Զ���1
create trigger insert_notice_cmnt on notice_cmnt
for insert
as 
begin 
   update notice set cmnt_count += 1
   from notice, inserted
   where notice.id = inserted.notice_id
end

go

--�� notice_reply ���в���һ������ʱ���� notice_cmnt �� reply_count �ֶ��Զ���1
create trigger insert_notice_reply on notice_reply
for insert
as 
begin 
   update notice_cmnt set reply_count += 1
   from notice_cmnt, inserted
   where notice_cmnt.id = inserted.cmnt_id
end

go

--�� BmdTopicJoin ���в���һ������ʱ���� BmdTopic �� JoinCount �ֶ��Զ��� 1
create trigger InsertBmdTopicJoin on BmdTopicJoin
for insert
as 
begin 
   update BmdTopic set JoinCount += 1
   from BmdTopic, inserted
   where BmdTopic.id = inserted.TopicId
end

go

--�� BmdNotice ���в���һ������ʱ BmdNoticeSpecie ���� NoticeCount �ֶ��Զ��� 1
create trigger InsertBmdNotice on BmdNotice
for insert
as 
begin 
   update BmdNoticeSpecie set NoticeCount += 1
   from BmdNoticeSpecie, inserted
   where BmdNoticeSpecie.Id = inserted.SpecieId
end

go

create trigger UpdateBmdNotice on BmdNotice
for update
as 
begin 
   if UPDATE(IsSolved)
	update BmdUser set HelpCount += 1
	from BmdUser, inserted
	where BmdUser.Id = inserted.UserId 
		and inserted.IsSolved = 1
		and inserted.Type like '����%'
end

go

--��goods_cmnt���в���һ������ʱ����goods��cmnt_count�ֶ��Զ���1
create trigger insert_goods_cmnt on goods_cmnt
for insert
as 
begin 
   update goods set cmnt_count += 1
   from goods, inserted
   where goods.id = inserted.goods_id
end

go


---- �� current ���в���һ������ʱ���� topic �� join_count�ֶ��Զ���1
--create trigger insert_current on [current]
--for insert
--as 
--begin 
--   update [topic] set [topic].[join_count] += 1
--   from [topic], inserted
--   where [topic].[id] = inserted.[topic_id]
--end

go

--�� current_cmnt ���в���һ������ʱ���� BmdCurrent ��cmnt_count�ֶ��Զ���1
create trigger InsertBmdCurrentCmnt on BmdCurrentCmnt
for insert
as 
begin 
   update BmdCurrent set BmdCurrent.CmntCount += 1
   from BmdCurrent, inserted
   where BmdCurrent.Id = inserted.CurrentId
end

go

create trigger insert_current_star on current_star
for insert
as 
begin 
   update [current] set [current].star_count += 1
   from [current], inserted
   where [current].id = inserted.current_id
end

go

--�� BmdCurrentCmntReply ���в���һ������ʱ���� BmdCurrentCmnt �� ReplyCount �ֶ��Զ���1
create trigger InsertBmdCurrentCmntReply on BmdCurrentCmntReply
for insert
as 
begin 
   update BmdCurrentCmnt set BmdCurrentCmnt.ReplyCount += 1
   from BmdCurrentCmnt, inserted
   where BmdCurrentCmnt.Id = inserted.CmntId
end

go

--�� follow ���в���һ������ʱ���� user �� following_count, follower_count �ֶ��Զ��� 1
create trigger InsertBmdUserFollow on [BmdUserFollow]
for insert
as
begin
  update [BmdUser] set [BmdUser].FollowerCount += 1
  from [BmdUser], inserted
  where [BmdUser].Id = inserted.FollowingId

  update [BmdUser] set [BmdUser].FollowingCount += 1
  from [BmdUser], inserted
  where [BmdUser].Id = inserted.UserId
end