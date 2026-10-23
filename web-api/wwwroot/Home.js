

const AddnewUser = async () => {
    if (currentPasswordScore < 2) {
        alert("לא ניתן להירשם. חובה להזין סיסמה שקיבלה ציון 2 ומעלה.");
        return;
    }
    try {

        const FirstName = document.querySelector(".firstname").value
        const LastName = document.querySelector(".lastname").value
        const Email = document.querySelector(".email").value
        const Password = document.querySelector(".password").value
        const Id=0

        const user = {Email, FirstName, LastName, Password,Id }
        const response = await fetch("api/users", {
            method: 'POST',
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
        alert(`The user ${data.firstName} - ${data.lastName} successfully added!!!!`)

    }
    catch (e) {
        alert(e)

    }



}
let currentPasswordScore = 0;

const CheckPassword = async () => {
    const password = document.querySelector(".password").value
    if (!password) {
        alert("נא להזין סיסמא")
        return
    }
    try {

        const response = await fetch("api/users/password", {
            method: 'POST',
            body: JSON.stringify(password),
            headers: {
                'Content-Type': 'application/json'
            }

        })
        if (!response.ok) {

            throw new Error(`Error status: ${response.status}`);
        }
        const data = await response.json();
        currentPasswordScore = JSON.stringify(data);
        
        document.querySelector("#passProgress").value = currentPasswordScore;
        if (currentPasswordScore < 2) {
            alert("הסיסמה חלשה מדי. אנא בחר סיסמה אחרת.");
        }

    }
    catch (e) {
        alert(e.message)
    }
    

}


const SighinUser = async () => {
    try {
        
        const Email = document.querySelector(".emailcomin").value
        const Password = document.querySelector(".passwordcomin").value
      

        const userin = { Email,Password }
        const response = await fetch("api/users/Login", {
            method: 'POST',
            body: JSON.stringify(userin),
            headers: {
                'Content-Type': 'application/json'
            }

        })
        if (!response.ok) {
           
            throw new Error(`Error status: ${response.status}`);
        }

        const data = await response.json();
        console.log(data)
        currentUserId = JSON.stringify(data)
        sessionStorage.setItem("currentUser",currentUserId)
     
        document.getElementById("text").innerText = `The user ${data.email} logged in successfully.`;
        document.getElementById("box").style.display = "block";
        document.getElementById("box").style.display = "flex";
        document.getElementById("in").style.display = "none";
        document.getElementById("signup").style.display = "none";
    }
    catch (e) {
        alert(e.message)

    }



}
const sighinin = document.getElementById("sighnin");
sighinin.addEventListener("click", () => {

    document.getElementById("signup").style.display = "block";
    document.getElementById("in").style.display = "none";
});
