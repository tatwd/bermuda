create trigger update_trace_count on notice_trace
for insert
as 
begin 
   update notice set trace_count += 1
   from notice, inserted
   where notice.id = inserted.notice_id
   --select trace_count 
   --from notice, inserted 
   --where notice.id = inserted.notice_id
end

go

insert into notice_trace values(1, 10001, '2017-12-10')