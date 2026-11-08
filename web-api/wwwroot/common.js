const CheckPassword = async (password) => {
    if (!password) {
        alert("נא להזין סיסמא");
        return 0;
    }
    try {
        const response = await fetch("api/passwords/password", {
            method: 'POST',
            body: JSON.stringify(password),
            headers: { 'Content-Type': 'application/json' }
        });
        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error status: ${response.status} , Message: ${errorText}`);
        }
        const score = Number(await response.json());

        const progress = document.querySelector("#passProgress");
        if (progress) progress.value = score;

        // if (score < 2 ) {
        //     alert("הסיסמה חלשה מדי. אנא בחר סיסמה אחרת.");
        // }
        return score;
    }
    catch (e) {
        alert(e.message);
        return 0;
    }
};