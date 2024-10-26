using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Student
    {
        // html 폼에 작성했던 input 필드의 내용과 매칭하는 속성들을 사용
        // java는 getter, setter를 작성 시 함수를 만들어줘야하지만 C#에서는 이렇게 작성

        // BindNever를 붙이면 이 변수만 제외하고 Controller로 넘어감
        //[BindNever]

        // 유효성 검사 - System.ComponentModel.DataAnnotations; 사용
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(15,70)]
        public int Age { get; set; }
        [Required, MinLength(5)]
        public string Country { get; set; }
    }
}
