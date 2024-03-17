select * from "Links";
select * from "Courses";
select linkname,"courseName","programSemesterName" from "LinkCourses","Courses","Links","ProgramSemesters"
         where "LinkCourses"."CourseID"="Courses"."courseID"
            and "LinkCourses"."LinkID"="Links"."linkID"
            and "Courses"."ProgrammeSemesterprogramSemesterID"="ProgramSemesters"."programSemesterID"

select linkname,"courseName","programSemesterName"
    from "LinkCourses","Courses","Links","ProgramSemesters"
        where "LinkCourses"."CourseID"="Courses"."courseID"
            and "LinkCourses"."LinkID"="Links"."linkID"
            and "Courses"."ProgrammeSemesterprogramSemesterID"="ProgramSemesters"."programSemesterID"
            and "Courses"."ProgrammeSemesterprogramSemesterID"='5d1b214e-a7ad-4065-9184-cf0c5a72091a';

select * from "Links" natural join "Courses";

select linkname,"courseName" from "Links" natural join "Courses";


-- Select ExamSchdule examdates and Courses
select "examDate","courseName"
    from "Courses", "ExamSchedules"
    where "Courses"."examScheduleID"="ExamSchedules"."examScheduleID"
            and "Courses"."ProgrammeSemesterprogramSemesterID"='5d1b214e-a7ad-4065-9184-cf0c5a72091a';


-- Generate examSchedule
select "examDate","programSemesterName","courseName"
    from "Courses","ExamSchedules","ProgramSemesters"
        where "Courses"."examScheduleID"="ExamSchedules"."examScheduleID"
            and "Courses"."ProgrammeSemesterprogramSemesterID"="ProgramSemesters"."programSemesterID"
            group by "examDate","programSemesterName","courseName";

-- Generate examSchedule for students
select *
    from "Courses","ExamSchedules","ProgramSemesters"
        where "Courses"."examScheduleID"="ExamSchedules"."examScheduleID"
            and "Courses"."ProgrammeSemesterprogramSemesterID"="ProgramSemesters"."programSemesterID"
            and "Courses"."ProgrammeSemesterprogramSemesterID"='5d1b214e-a7ad-4065-9184-cf0c5a72091a';

UPDATE "Courses" set "examScheduleID"=null
    where "courseName"='CSE 103';

update "Courses" set "examScheduleID"='96f11678-06ff-4f4c-8ce6-b1d97f3ee812'
    where "courseName"='EEE 103';


delete from "LinkExamDates";


-- Model Recommendations
select *
    from "Courses";

select "LinkID","courseName", "courseID"
    from "LinkCourses","Courses"
        where "LinkCourses"."CourseID"="Courses"."courseID";


select linkname,"courseName","examDate","Priority"
    from "Links","LinkCourses","LinkExamDates","ExamSchedules","Courses"
        where "Links"."linkID"="LinkCourses"."LinkID"
            and "LinkCourses"."LinkID"="LinkExamDates"."LinkID"
            and "LinkExamDates"."ExamScheduleID"="ExamSchedules"."examScheduleID"
            and "LinkCourses"."CourseID"="Courses"."courseID";


select linkname,"courseName","examDate","Priority"
    from "Courses","LinkCourses","Links","LinkExamDates","ExamSchedules"
        where "Courses"."courseID"="LinkCourses"."CourseID"
            and "LinkCourses"."LinkID"="Links"."linkID"
            and "Links"."linkID"="LinkExamDates"."LinkID"
            and "LinkExamDates"."ExamScheduleID"="ExamSchedules"."examScheduleID";

select linkname,"courseName"
    from "LinkCourses","Links", "Courses"
        where "LinkCourses"."LinkID"="Links"."linkID"
            and "LinkCourses"."CourseID"="Courses"."courseID";



delete from "Students" where "StudentID"=200012158;
delete from "Departments" where "departmentName"='BTM';

select linkname,"courseName","examDate","Priority"
    from "Courses","LinkCourses","Links","LinkExamDates","ExamSchedules"
        where "Courses"."courseID"="LinkCourses"."CourseID"
            and "LinkCourses"."LinkID"="Links"."linkID"
            and "Links"."linkID"="LinkExamDates"."LinkID"
            and "LinkExamDates"."ExamScheduleID"="ExamSchedules"."examScheduleID";

select "courseName","examDate","programSemesterName"
    from "Courses","ExamSchedules","ProgramSemesters"
        where "Courses"."ProgrammeSemesterprogramSemesterID"="ProgramSemesters"."programSemesterID"
            and "Courses"."examScheduleID"="ExamSchedules"."examScheduleID"

update "Courses" set "examScheduleID"= null where "courseName"='CSE 101';

a33c11aa-364f-44a6-bc3c-ee73648f7a5b

delete from "LinkExamDates";


select * from "Courses";

delete from "LinkExamDates";


select linkname,"courseName","examDate","Priority"
    from (select * from "Courses") as a
        where "Courses"."courseID"="LinkCourses"."CourseID"
            and "LinkCourses"."LinkID"="Links"."linkID"
            and "Links"."linkID"="LinkExamDates"."LinkID"
            and "LinkExamDates"."ExamScheduleID"="ExamSchedules"."examScheduleID";


select "examDate" from "ExamSchedules";


select count("programSemesterID")
    from "ProgramSemesters";

select count("programSemesterID")
    from "LinkExamDates";

-- Find unique program semester id count
select count(distinct "programSemesterID")
    from "LinkExamDates";


update "Students" set "Validity"=false where "StudentID"=200012158;

delete from "Links" where "linkID"='86dbc6b3-f5d4-406a-b5d1-c98594cfe95b';
update "Courses" set "examScheduleID"=null;

delete from "LinkExamDates"

