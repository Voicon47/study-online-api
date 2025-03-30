namespace web_back.Entities
{
    public class Banner
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Thumbnails { get; set; }
        public string ActionLink { get; set; }
        public string BtnTitle { get; set; }
        public string StartColor { get; set; }
        public string EndColor { get; set; }
        public Banner() { }
        public Banner(string title, string subtitle, string thumbnails, string actionLink, string btnTitle, string startColor, string endColor)
        {
            Title = title;
            Subtitle = subtitle;
            Thumbnails = thumbnails;
            ActionLink = actionLink;
            BtnTitle = btnTitle;
            StartColor = startColor;
            EndColor = endColor;
        }
        public List<Banner> GetExampleData()
        {
            var banners = new List<Banner>();

            banners.Add(new Banner(
        "New Skill with Course EDU",
        "Miễn phí tài nguyên, dễ dàng đăng ký và tự học",
        "https://i.pinimg.com/736x/6f/6e/3a/6f6e3a38607e5ea5f83e69eb39e0f97a.jpg",
        "/",
        "Học ngay",
        "#fe6ba4",
        "#8b65dc"
    ));

            banners.Add(new Banner(
                "Course EDU đăng ký ngay",
                "Course EDU với nhiều khóa học miễn phí, bao gồm tài liệu, bài làm và video ,...",
                "https://i.pinimg.com/736x/29/11/ef/2911efdef68e6e58526df271524a03fa.jpg",
                "/",
                "Tham gia ngay",
                "#fe6ba4",
                "#8b65dc"
            ));

            banners.Add(new Banner(
        "Swift & Reliable",
        "Course EDU với nhiều khóa học miễn phí, bao gồm tài liệu, bài làm và video ,...",
        "https://i.pinimg.com/736x/6f/a6/4b/6fa64b0e34a258889902162f7ab6fcc8.jpg",
        "/",
        "Học Ngay",
        "#04DF80",
        "#032115"
    ));

            banners.Add(new Banner(
    "Phát triển website cho người mới bắt đầu",
    "Khóa học giúp bạn phát triển một website theo đúng quy trình từ A đến Z",
    "https://i.pinimg.com/736x/28/b4/19/28b419bda388dd7c43094b8d548ab037.jpg",
    "/",
    "Tham gia ngay",
    "#007251",
    "##02FFD3"
));

            banners.Add(new Banner(
            "Master Your Coding Skills",
            "Học lập trình với các khoá học miễn phí, thực hành với dự án thực tế.",
            "https://img-c.udemycdn.com/course/240x135/6051535_20d3_3.jpg",
            "/",
            "Bắt đầu học",
            "#6AB04A",
            "#2B7A0B"
        ));

            banners.Add(new Banner(
                "Digital Marketing Essentials",
                "Nắm vững nền tảng Digital Marketing với khóa học từ cơ bản đến nâng cao.",
                "https://res.cloudinary.com/dcyfz1emw/image/upload/v1730780233/pkbcli3sbwwdu5iriguc.png",
                "/",
                "Tham gia ngay",
                "#00B894",
                "#016936"
            ));

            banners.Add(new Banner(
                "Become a Graphic Design Pro",
                "Học thiết kế đồ họa với tài liệu miễn phí và hướng dẫn chuyên sâu.",
                "https://res.cloudinary.com/dcyfz1emw/image/upload/v1731480318/gka8bcm9lbditqi9akcd.jpgg",
                "/",
                "Khám phá ngay",
                "#27AE60",
                "#145A32"
            ));

            banners.Add(new Banner(
                "Data Science for Beginners",
                "Học các kỹ năng phân tích dữ liệu từ cơ bản đến nâng cao với khóa học chi tiết.",
                "https://res.cloudinary.com/dcyfz1emw/image/upload/v1728274974/urx80yvmmpfqip9b0hpj.jpg",
                "/",
                "Đăng ký ngay",
                "#2ECC71",
                "#1E8449"
            ));

            banners.Add(new Banner(
                "Boost Your Excel Skills",
                "Tăng cường kỹ năng Excel với các mẹo và hướng dẫn hữu ích cho người mới.",
                "https://res.cloudinary.com/dcyfz1emw/image/upload/v1726893577/zdr818jsdpexfjas31da.png",
                "/",
                "Bắt đầu ngay",
                "#58D68D",
                "#117A65"
            ));

            return banners;
        }
    }
}
