function showBannerAndContent(bannerName, contentName, button) {
  // Hide all banners except the selected one
  var banners = document.getElementsByClassName("about-banner");
  for (var i = 0; i < banners.length; i++) {
      if (banners[i].id === bannerName + "Banner") {
          banners[i].style.display = "block";
      } else {
          banners[i].style.display = "none";
      }
  }

  // Hide all content sections except the selected one
  var contents = document.getElementsByClassName("tab-content");
  for (var i = 0; i < contents.length; i++) {
      if (contents[i].id === contentName + "Content") {
          contents[i].style.display = "block";
      } else {
          contents[i].style.display = "none";
      }
  }

  // Update active state of buttons
  var buttons = document.getElementsByClassName("tab-btn");
  for (var i = 0; i < buttons.length; i++) {
      buttons[i].classList.remove("active");
  }
  button.classList.add("active");
}
