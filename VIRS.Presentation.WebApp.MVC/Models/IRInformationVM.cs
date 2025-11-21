using System.ComponentModel.DataAnnotations;

namespace VIRS.Presentation.WebApp.MVC.Models
{
    public class IRInformationVM
    {
        [Required(ErrorMessage = "شماره ملی الزامی است")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "شماره ملی باید 10 رقم باشد")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "شماره ملی باید فقط شامل عدد باشد")]
        public string NID { get; set; }

        [Required(ErrorMessage = "نام الزامی است")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "شماره تماس الزامی است")]
        [Phone(ErrorMessage = "شماره تماس نامعتبر است")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس باید 11 رقم باشد")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تماس باید فقط شامل عدد باشد و با 09 شروع شود")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "بخش اول پلاک الزامی است")]
        [Range(11, 99, ErrorMessage = "بخش اول پلاک باید 2 رقمی باشد")]
        public int CarPlatFirstPart { get; set; }

        [Required(ErrorMessage = "بخش حروف پلاک الزامی است")]
        [RegularExpression("^(الف|ب|پ|ت|ث|ج|چ|ح|خ|د|ذ|ر|ز|ژ|س|ش|ص|ض|ط|ظ|ع|غ|ف|ق|ک|گ|ل|م|ن|و|ه|ی)$",
            ErrorMessage = "فقط یکی از حروف مجاز پلاک ایران قابل قبول است")]
        public string CarPlatLetter { get; set; }

        [Required(ErrorMessage = "بخش دوم پلاک الزامی است")]
        [Range(111, 999, ErrorMessage = "بخش دوم پلاک باید 3 رقمی باشد")]
        public int CarPlatSecondPart { get; set; }

        [Required(ErrorMessage = "کد شهرستان پلاک الزامی است")]
        [Range(10, 99, ErrorMessage = "کد شهرستان پلاک باید 2 رقمی باشد")]
        public int CarPlatProvinceCode { get; set; }

        [Required(ErrorMessage = "شناسه یکتای خودرو الزامی است")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "شناسه یکتای خودرو باید 17 کاراکتر باشد")]
        public string CarVIN { get; set; }

        [Required(ErrorMessage = "سال تولید خودرو الزامی است")]
        [Range(1350, 1450, ErrorMessage = "سال تولید خودرو باید بین 1350 تا 1450 باشد")]
        public int CarManufactureYear { get; set; }

        [Required(ErrorMessage = "کارخانه سازنده خودرو را انتخاب کنید")]
        public string CarModelManufacturer { get; set; }

        [Required(ErrorMessage = "خانواده خودرو خود را انتخاب کنید")]
        public string CarModelFamily { get; set; }

        [Required(ErrorMessage = "نام مدل خودروی خود را انتخاب کنید")]
        public string CarModelName { get; set; }

        [Required(ErrorMessage = "زمان مراجعه خود را تعیین کنید")]
        public DateTime InspectionDate { get; set; }

        [Required(ErrorMessage = "تصاویر درخواست شده را اپلود کنید")]
        public List<IFormFile> Images { get; set; }
    }
}
