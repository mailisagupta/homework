namespace HelloWebService
{
    public class JsonClass
    {

        public string firstName;
        public string lastName;
        public bool isAlive;
        public int age;
        public Phone[] phoneNumbers;
        public JsonClass[] children;
        public JsonClass spouse;
    }

    public class Phone
    {
        public string type;
        public string number;
    }
    public class Course
    {
        public int CourseId;
        public string Name;
    }

    public class Student
    {
        public int StudentId;
        public string Name;
        public Course[] Courses;
    }

    //var students = new Student[]
    //{
    //new Student {
    //    StudentId = 101,
    //    Name = "Steve",
    //    Courses = new[] {
    //        new Course { CourseId = 101, Name = "C#"},
    //        new Course {CourseId = 201, Name = "Advanced C#"}
    //        }
    //},
    //new Student {
    //    StudentId = 201,
    //    Name = "Dave"
    //}
    //};

   
}

//JSON-REQUEST
// [
//{
//    "StudentId": 101,
//    "Name": "Steve" ,
//    "Courses": [
//    {
//    "CourseId" : 101,
//    "Name": "C#"
//    },
//    {
//    "CourseId" : 201,
//    "Name": "Advanced C#"
//    }]
//}
//,{
// "StudentId": 201,
// "Name": "Dave" 
//}
 // ]
