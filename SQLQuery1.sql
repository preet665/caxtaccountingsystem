select * from (SELECT top 7 ID,SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,CrAmount,DebAmount,status,enrtydatetime,loggedinuser,
SUM(isnull(CrAmount, 0) - isnull(DebAmount, 0)) OVER (ORDER BY id ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) as Balance FROM newentrytable  
where SMK = '1254' order by enrtydatetime desc) as temp order by enrtydatetime asc;