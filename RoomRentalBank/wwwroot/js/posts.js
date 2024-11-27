document.addEventListener("DOMContentLoaded", () => {
    const editModal = document.getElementById("editModal");
    const closeModal = document.getElementById("closeModal");
    const notification = document.getElementById("notification");

    // Sửa bài đăng
    document.querySelectorAll(".card-edit").forEach(button => {
        button.addEventListener("click", (e) => {
            const postId = e.target.getAttribute("data-post-id");

            // Lấy thông tin bài đăng
            fetch(`/Post/GetPostById/${postId}`)
                .then(response => response.json())
                .then(data => {
                    document.getElementById("editPostId").value = data.postId;
                    document.getElementById("editAddress").value = data.address;
                    document.getElementById("editPrice").value = data.price;
                    document.getElementById("editDescription").value = data.description;
                    document.getElementById("editArea").value = data.area;

                    // Hiển thị modal
                    document.getElementById("editModal").style.display = "block";
                });

        });
    });

    // Lưu thay đổi
    document.getElementById("editForm").addEventListener("submit", (e) => {
        e.preventDefault();

        const postId = document.getElementById("editPostId").value;
        const updatedData = {
            Address: document.getElementById("editAddress").value,
            Price: parseFloat(document.getElementById("editPrice").value),
            Description: document.getElementById("editDescription").value,
            Area: parseFloat(document.getElementById("editArea").value),
        };

        fetch(`/Post/UpdatePost/${postId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(updatedData),
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    notification.innerText = "Bài đăng đã được cập nhật!";
                    notification.style.display = "block";

                    document.getElementById("editModal").style.display = "none";
                    updatePostInView(postId, updatedData);

                    setTimeout(() => {
                        notification.style.display = "none";
                    }, 2000); 
                } else {
                    notification.innerText = data.message;
                    notification.classList.add("error");
                    notification.style.display = "block";
                }
            });
    });

    // Xóa bài đăng
    document.querySelectorAll(".card-delete").forEach(button => {
        button.addEventListener("click", (e) => {
            const postId = e.target.getAttribute("data-post-id");

            fetch(`/Post/DeletePost/${postId}`, { method: "DELETE" })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // Thông báo xóa thành công
                        notification.innerText = "Bài đăng đã được xóa!";
                        notification.style.display = "block";

                        // Xóa phần tử bài đăng khỏi DOM
                        const postCard = e.target.closest('.card');
                        postCard.remove();

                        setTimeout(() => {
                            notification.style.display = "none";
                        }, 2000); 
                    } else {
                        notification.innerText = data.message;
                        notification.classList.add("error");
                        notification.style.display = "block";
                    }
                });
        });
    });


    // Đóng modal
    closeModal.addEventListener("click", () => {
        editModal.style.display = "none";
    });

    function updatePostInView(postId, updatedData) {
        // Tìm phần tử bài đăng có postId
        const postCard = document.querySelector(`[data-post-id='${postId}']`);
        const postPrice = updatedData.Price;
        const formattedPrice = postPrice.toLocaleString('vi-VN') + ' ₫'; 

        if (postCard) {
            console.log(updatedData);
            
        }

        // Cập nhật các giá trị mới vào giao diện
        postCard.querySelector('.card-address-text').innerText = updatedData.Address;
        postCard.querySelector('.card-price-text').innerText = formattedPrice;
        postCard.querySelector('.card-title').innerText = updatedData.Description;
        postCard.querySelector('.card-area-text').textContent = updatedData.Area;
    }
});

//function updatePost(postId) {
//    const updatedPost = {
//        Address: document.getElementById("editAddress").value,
//        Price: parseFloat(document.getElementById("editPrice").value),
//        Description: document.getElementById("editDescription").value,
//        Area: parseFloat(document.getElementById("editArea").value),
//        ImageUrls: document.getElementById("editImageUrls").value
//    };

//    fetch(`/Post/UpdatePost/${postId}`, {
//        method: 'PUT',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(updatedPost)
//    })
//        .then(response => response.json())
//        .then(data => {
//            if (data.success) {
//                alert(data.message);
//                location.reload(); // Refresh lại trang sau khi cập nhật
//            } else {
//                alert("Cập nhật thất bại: " + data.message);
//            }
//        })
//        .catch(error => {
//            console.error("Lỗi:", error);
//            alert("Không thể gửi yêu cầu. Vui lòng thử lại!");
//        });
//}


