
    var selectedLessonId = null;

    $(document).ready(function () {
        $.get("/api/lesson", function (data) {
            var lessons = data;

            // Hiển thị danh sách các bài học
            if (lessons && lessons.length > 0) {
                var lessonHtml = "<ul>";
                lessons.forEach(function (lesson) {
                    lessonHtml += "<li><a href='#' class='lesson-link' data-lesson-id='" + lesson.id + "'>" + lesson.name + "</a></li>";
                });
                lessonHtml += "</ul>";
                $("#lessonData").html(lessonHtml);
            } else {
                $("#lessonData").html("<p>No lessons available</p>");
            }
        }).fail(function () {
            $("#lessonData").html("<p>Failed to load lessons</p>");
        });
    });

    // Hàm để tải các ví dụ dựa trên id của bài học và hiển thị chúng trong div exampleList
    function loadExamples(lessonId) {
        selectedLessonId = lessonId; // Cập nhật ID của bài học được chọn
    $.get("/api/lesson/" + lessonId + "/examples", function (data) {
            // Xử lý dữ liệu trả về từ API
            var examples = data;

            // Hiển thị danh sách các ví dụ
            if (examples && examples.length > 0) {
                var exampleHtml = "<ul>";
        examples.forEach(function (example) {
            exampleHtml += "<li><a href='#' class='example-link' data-example-id='" + example.exampleId + "'>" + example.name + "</a></li>";
                });
        exampleHtml += "</ul>";
    $("#exampleList").html(exampleHtml);
            } else {
        $("#exampleList").html("<p>No examples available</p>");
            }
        }).fail(function () {
        $("#exampleList").html("<p>Failed to load examples</p>");
        });
    }

    // Sự kiện click cho các liên kết bài học
    $(document).on("click", ".lesson-link", function (e) {
        e.preventDefault();
    var lessonId = $(this).data("lesson-id");
    loadExamples(lessonId);
    // Xóa nội dung của contentDetails khi nhấn vào một bài học mới
    $("#contentDetails").html("");
    });

    // Sự kiện click cho các liên kết ví dụ
    $(document).on("click", ".example-link", function (e) {
        e.preventDefault();
    var exampleId = $(this).data("example-id");
    loadExampleContents(exampleId);
    });

    // Hàm để tải các nội dung ví dụ dựa trên id của ví dụ và hiển thị chúng trong div contentDetails
    function loadExampleContents(exampleId) {
        // Kiểm tra xem đã chọn một bài học nào chưa
        if (selectedLessonId !== null) {
        $.get("/api/lesson/" + exampleId + "/examplecontents", function (contents) {
            // Hiển thị danh sách các nội dung ví dụ
            var contentHtml = "";
            if (contents && contents.length > 0) {
                contents.forEach(function (content) {
                    contentHtml += "<div>";
                    contentHtml += "<h3>" + content.name + "</h3>";
                    contentHtml += "<p>" + content.content + "</p>";
                    if (content.imgExample) {
                        contentHtml += "<img src='" + content.imgExample + "' alt='" + content.name + "' />";
                    }
                    if (content.Description) {
                        contentHtml += "<p>Description: " + content.Description + "</p>";
                    }
                    contentHtml += "</div>";
                });
            } else {
                contentHtml = "<p>No content available</p>";
            }

            // Đồng thời gọi API contentdetails và hiển thị danh sách chi tiết nội dung
            $.get("/api/lesson/" + exampleId + "/contentdetails", function (details) {
                var detailsHtml = "";
                if (details && details.length > 0) {
                    detailsHtml += "<div>";
                    detailsHtml += "<h3>Example</h3>";
                    detailsHtml += "<ul>";
                    details.forEach(function (detail) {
                        detailsHtml += "<li>Title: " + detail.title + "</li>";
                        if (detail.Description) {
                            detailsHtml += "<li>Description: " + detail.Description + "</li>";
                        }
                        if (detail.code) {
                            detailsHtml += "<li>Code: <pre class='code'>" + detail.code + "</pre></li>";
                        }

                    });
                    detailsHtml += "</ul>";
                    detailsHtml += "</div>";
                } else {
                    detailsHtml = "<p>No details available</p>";
                }

                // Hiển thị cả hai danh sách trong cùng một div
                $("#contentDetails").html(contentHtml + detailsHtml);
            }).fail(function () {
                $("#contentDetails").html("<p>Failed to load content details</p>");
            });
        }).fail(function () {
            $("#contentDetails").html("<p>Failed to load example contents</p>");
        });
        }
    }


