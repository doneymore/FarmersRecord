using FarmersRecord.Dtos;
using FarmersRecord.FarmersRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepo _loginrepo;
        public LoginController(ILoginRepo login)
        {
            _loginrepo = login;
        }

        [HttpPost, Route("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginDto logindto)
        {
            var response = await _loginrepo.LoginUser(logindto);
            if (response.ResponseCode == "00")
                return Ok(response);
            return BadRequest(response);
        }


        //TO STUDY THE CONDITIONS USED IN CHECKING IF A RECORD EXIST BEFORE ADDING TO DB
        //[HttpPost, AllowAnonymous]
        //[Route("api/AddStudents")]
        //public async Task<ResponseMessage> AddStudents([FromBody] List<NewStudent> students, [FromUri] int schId, [FromUri] int levelId)
        //{
        //    using (db = new FedPolyBida_PortalAcademyDBEntities())
        //    {
        //        try
        //        {
        //            // var ap = db.Applicants.FirstOrDefault(x=>x.ApplicantID == x.ApplicantID);
        //            int studentExist = 0;
        //            if (students.GroupBy(x => x.Email.ToString().ToLower()).Any(grp => grp.Count() > 1))
        //                return new ResponseMessage { Status = "Declined", Message = "Duplicate Emails exist. Remove the duplicates and try again" };
        //            var lmsResponse = "";
        //            var photo = string.Empty;
        //            foreach (var student in students)
        //            {
        //                var appl = db.Applicants.SingleOrDefault(a => a.Email == student.Email);
        //                //var deptId = (db.Departments.FirstOrDefault(a =>
        //                //        a.DepartmentName.Equals(student.Department, StringComparison.CurrentCultureIgnoreCase))
        //                //    ?.DepartmentID ?? Guid.Empty);

        //                if (student.JambRegNo != null)
        //                {
        //                    var fileUrl = student.JambRegNo + "_Face.jpg";

        //                    var upload = uploadFile.UploadFile000(student.FileUpload.Image, fileUrl, "passport");

        //                    // return new ResponseMessage { Data2 = Upload.Result, Data = Upload.Status };

        //                    photo = upload.Result.FileUri;

        //                    //}
        //                }

        //                // return new ResponseMessage { Data2 = Upload.Result, Data = Upload.Status };

        //                var checkstudent1 = db.StudentRegDetails.FirstOrDefault(a => a.Email == student.Email);
        //                if (checkstudent1 == null)
        //                {

        //                    //var matSetup = await matricNoSetup.GetMatricNo(schId, levelId, deptId, student.Email);
        //                    //if (matSetup == null)
        //                    //{
        //                    //    return new ResponseMessage
        //                    //    { Status = "Error", Message = "Error encountered while trying to create Matric no!" };
        //                    //}
        //                    //UploadPassport(datas);
        //                    var data = db.StudentRegDetails.Add(new StudentRegDetail()

        //                    {
        //                        //ApplicantId = Guid.Parse(HttpUtility.HtmlEncode(appl.ApplicantID)),
        //                        Passport = photo == string.Empty ? null : photo,
        //                        StudId = Guid.NewGuid(),
        //                        SchoolID = schId,
        //                        AdmModeId = 12,
        //                        FirstName = HttpUtility.HtmlEncode(student.FirstName),
        //                        OtherName = HttpUtility.HtmlEncode(student.OtherName),
        //                        LastName = HttpUtility.HtmlEncode(student.LastName),
        //                        Email = HttpUtility.HtmlEncode(student.Email.ToLower()),
        //                        LGAID = int.Parse(HttpUtility.HtmlEncode(student.LGAID)),
        //                        PhoneNumber = HttpUtility.HtmlEncode(student.PhoneNumber),
        //                        StateID = int.Parse(HttpUtility.HtmlEncode(student.StateId)),
        //                        MaritalID = int.Parse(HttpUtility.HtmlEncode(student.MaritalID)),
        //                        TitleId = int.Parse(HttpUtility.HtmlEncode(student.TitleId)),
        //                        //GenotypeId = int.Parse(HttpUtility.HtmlEncode(student.GenotypeId)),
        //                        BloodGroupId = int.Parse(HttpUtility.HtmlEncode(student.BloodGroupId)),
        //                        //Passport = HttpUtility.HtmlEncode(student.Passport),
        //                        CourseOfStudyId = Guid.Parse(HttpUtility.HtmlEncode(student.CourseOfStudyId)),
        //                        Gender = HttpUtility.HtmlEncode(student.Gender),
        //                        DOB = student.DOB,
        //                        LevelId = int.Parse(HttpUtility.HtmlEncode(student.LevelId)),
        //                        CurrentSessionId = int.Parse(HttpUtility.HtmlEncode(student.CurrentSessionId)),
        //                        //DeptID = deptId,
        //                        DeptID = db.DeptCourseofStudies.FirstOrDefault(x => x.CourseStudyId == student.CourseOfStudyId).DepartmentId,
        //                        MatricNumber = student.MatricNumber,
        //                        ProfileUpdated = false,
        //                        isCleared = false,
        //                        isGraduated = false,
        //                        DateAdmitted = DateTime.Now,
        //                        IsAcceptancePaid = false,
        //                        StatusID = (int)StudentStatus.Active,
        //                        JambRegNo = student.JambRegNo,
        //                        CountryID = student.CountryId,
        //                        EntryModeId = student.EntryModeId,
        //                        Address = student.Address,
        //                        ParentName = student.ParentName,
        //                        ParentPhoneNumber = student.ParentPhoneNumber,
        //                        ParentAddress = student.ParentAddress,
        //                        AdmittedSessionId = student.AdmittedSessionId

        //                    });


        //                    // UploadPassport(datas);
        //                    db.SaveChanges();

        //                }

               

        //                else
        //                {
        //                    studentExist++;
        //                }

        //            }

        //            if (studentExist == 0)
        //                return new ResponseMessage { Status = "Ok", Message = $"Student Added Successfully. {lmsResponse}", Data = "" };
        //            {
        //                return new ResponseMessage { Status = "Ok", Message = $"Upload Complete. {studentExist} student has been skipped because they have been uploaded already. Other student's login credentials has been sent to their respective email addresses. {lmsResponse}", Data = "" };

        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            return new ResponseMessage { Status = "Error", Message = "An error was encountered" };
        //        }
        //    }
        //}

    }
}
