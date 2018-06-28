create trigger insert_notice on notice
for insert
as
begin 
  update notice
  set notice.status = '未找回'
  from notice, inserted
  where notice.id = inserted.id
    and notice.type like '寻物%'

  update notice
  set notice.status = '未领回'
  from notice, inserted
  where notice.id = inserted.id
    and notice.type like '招领%'
end