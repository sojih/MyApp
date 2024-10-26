using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        
        // Views 폴더 안에 해당 컨트롤러(HomeController) 접두사(Home) 폴더 안, lazor view 파일(Student.cshtml) 이름과 같은 이름으로 지정
        public IActionResult Student()
        {
            // view를 return 할 때 asp.net core mvc 룰에 따라야 함

            return View();
        }

        // 위 함수 : student.cshtml 레이저 파일을 디스플레이
        // 아래 함수 : http 포스트르 붙임 -> html 뷰에서 온 값들을 받는 함수

        // http 포스트 attribute 특성이 있는 action 함수를 만들어야 view에서 받은 정보가 전달됨
        // 자동적으로 복합 유형 매개변수를 Student 타입으로 매핑해서 받아옴
        // (Age, Country, Name 각각 받아옴)
        // Bind를 사용해서 받고 싶은 변수만 받을 수 있음 (Country값은 null이 됨)
        // 제외하고 싶은 항목이 있을때는 Model 파일에 Bind-never라는 코드 추가

        // 유저가 서버로 form을 보낼 때 이게 유저에게 제공된 그 form이 맞는지 토큰을 비교해 서버에서 차단을 결정
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Student(Student model)
        //public IActionResult Student([Bind("Name, Age")] Student model) 
        {
            // HttpHost 요청으로 들어왔을 때 이 모델값들이 유효한 값인지 검사하는 코드
            if (ModelState.IsValid)
            {
                // 유효한 값인 경우 model 테이터를 Student 테이블에 저장
            }
            else
            {
                // 에러를 보여줌

            }
            return View();
        }
    }
}
