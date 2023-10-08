

function showRegister(){
    document.getElementById('login-div').style.display = 'none';
    document.getElementById('register-div').style.display = 'block';
    document.getElementById('wrapper').style.height = '620px';
}

function showLogin(){
    document.getElementById('login-div').style.display = 'block';
    document.getElementById('register-div').style.display = 'none';
    document.getElementById('wrapper').style.height = '540px';
}



document.getElementById('reg-button').onclick = function () {
    var regLogin = document.getElementById("reg-login-input").value;
    var regPassword = document.getElementById("reg-password-input").value;
    var regEmail = document.getElementById("reg-email-input").value;

    const usernamePattern = /^[a-zA-Z0-9]{4,20}$/;
    if (!regLogin.match(usernamePattern)) {
        document.getElementById('reg-error-login').style.display = 'block';
        return;
    }
    else {
        document.getElementById('reg-error-login').style.display = 'none';
    }
    const emailPattern = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
    if (!regEmail.match(emailPattern)) {
        document.getElementById('reg-error-email').style.display = 'block';
        return;
    }
    else {
        document.getElementById('reg-error-email').style.display = 'none';
    }
    const passwordPattern = /^[a-zA-Z0-9]{6,20}$/;
    if (!regPassword.match(passwordPattern)) {
        document.getElementById('reg-error-pass').style.display = 'block';
        return;
    }
    else {
        document.getElementById('reg-error-pass').style.display = 'none';
    }

    
    mp.trigger("CEF:CLIENT::REGISTER_BUTTON_CLICKED", regLogin, regPassword, regEmail)
    const OnRegisterExists = () => {
        document.getElementById('reg-error2').style.display = 'block';
    }
    document.addEventListener('registerExists', OnRegisterExists)

    
    
    
   
};
document.getElementById('login-button').onclick = function () {
    
    var logLogin = document.getElementById("login-login-input").value;
    var logPassword = document.getElementById("login-password-input").value;
    

    const usernamePattern = /^[a-zA-Z0-9]{4,20}$/;
    if (!logLogin.match(usernamePattern)) {
        document.getElementById('login-error-login').style.display = 'block';
        return;
    }
    else {
        document.getElementById('login-error-login').style.display = 'none';
    }
    const passwordPattern = /^[a-zA-Z0-9]{6,20}$/;
    if (!logPassword.match(passwordPattern)) {
        document.getElementById('login-error-pass').style.display = 'block';
        return;
    }
    else {
        document.getElementById('login-error-pass').style.display = 'none';
    }


    mp.trigger("CEF:CLIENT::LOGIN_BUTTON_CLICKED", logLogin, logPassword)
    const OnLoginNotValidData = () =>
    {
        document.getElementById('login-error').style.display = 'block';
    }
    document.addEventListener('loginNotValidData', OnLoginNotValidData)




};
