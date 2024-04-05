document.addEventListener("DOMContentLoaded", function() {
    // Lấy đối tượng văn bản và chuỗi văn bản
    var textElement = document.getElementById("welcomeText");
    var textContent = textElement.textContent;

    // Xóa nội dung ban đầu
    textElement.textContent = "";

    // Khởi tạo các biến cần thiết
    var currentIndex = 0;
    var animationDelay = 100; // Độ trễ giữa mỗi ký tự
    var loopDelay = 3000; // Thời gian chờ trước khi bắt đầu lại hiệu ứng

    // Hàm thực hiện hiệu ứng xuất hiện từng chữ cái một
    function animateText() {
        if (currentIndex < textContent.length) {
            // Thêm chữ cái tiếp theo vào văn bản
            textElement.textContent += textContent[currentIndex];
            currentIndex++;
            // Lặp lại hàm sau mỗi khoảng thời gian animationDelay
            setTimeout(animateText, animationDelay);
        } else {
            // Đợi một khoảng thời gian trước khi bắt đầu lại hiệu ứng
            setTimeout(resetAnimation, loopDelay);
        }
    }

    // Hàm đặt lại hiệu ứng
    function resetAnimation() {
        textElement.textContent = ""; // Xóa văn bản hiện tại
        currentIndex = 0; // Đặt lại chỉ số hiện tại về 0
        // Gọi hàm hiệu ứng lại
        animateText(); // Thực hiện lại hiệu ứng
    }

    // Bắt đầu hiệu ứng khi trang được tải
    animateText();
});