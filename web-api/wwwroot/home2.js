


document.addEventListener("DOMContentLoaded", () => {
    const updateBtn = document.getElementById("updateBtn");
    if (updateBtn) {
        const c_User = JSON.parse(sessionStorage.getItem("currentUser"));
        if (c_User ==null) {
            window.location.href = "home.html"; 
            return;
        }
        document.querySelector(".firstnameup").value = c_User.firstName
        document.querySelector(".lastnameup").value = c_User.lastName
        document.querySelector(".passwordup").value = c_User.password
        document.querySelector(".emailup").value = c_User.email
        updateBtn.addEventListener("click", UpdateUser);
    }
   
});
//עדכון פרטים
const UpdateUser = async () => {
    try {

        const c_User = JSON.parse(sessionStorage.getItem("currentUser"));
        
        const FirstName = document.querySelector(".firstnameup").value
        const LastName = document.querySelector(".lastnameup").value
        const Email = document.querySelector(".emailup").value
        const Password = document.querySelector(".passwordup").value

        const Id = c_User.id

        const user = { Email, FirstName, LastName, Password, Id }
        const response = await fetch("api/users/" + c_User.id, {
            method: 'PUT',
            body: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json'
            }

        })
        if (!response.ok) {

            throw new Error(`Error status: ${response.status}`);
        }

        const data = await response.json();
        currentUserId = JSON.stringify(data)
        sessionStorage.setItem("currentUser", currentUserId)
        alert(`The user ${data.firstName} - ${data.lastName} Updated successfully!!!`)

    }
    catch (e) {
        alert(e)

    }



}