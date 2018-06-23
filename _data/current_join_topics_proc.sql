use [bermuda-mvc]
go

if (object_id('JoinTopicsProc ', 'P') is not null)
  drop proc JoinTopicsProc
go

create proc JoinTopicsProc (
  @user_id bigint,
  @title varchar(100),
  @text text,
  
  @topic1_id bigint = 0,
  @topic2_id bigint = 0,
  @topic3_id bigint = 0
)
as 
  insert into BmdCurrent(UserId, Title, Text)
  values(@user_id, @title, @text)

  declare @current_id bigint
  set @current_id = IDENT_CURRENT('BmdCurrent')
  --select @current_id = Id
  --from BmdCurrent
  --where UserId = @user_id
  --  and Title = @title
  --  and Text = @text
  
  if @topic1_id != 0
    insert into BmdTopicJoin(TopicId, CurrentId)
    values(@topic1_id, @current_id)

  if @topic2_id != 0
    insert into BmdTopicJoin(TopicId, CurrentId)
    values(@topic2_id, @current_id)

  if @topic3_id != 0  
    insert into BmdTopicJoin(TopicId, CurrentId)
    values(@topic3_id, @current_id)
go

--exec JoinTopicsProc 10001, 'use proc to add current 2nd', '<p>use proc to add a current 2ndly, then add TopicJoin records.</p>', 1, 2