//Working with Auth
const auth = getAuth();
//retrieve element from form 
var frmCreateUser  = document.getElementById("frmCreateUser");
//we create a button listener to listen wwhen someone clicks
frmCreateUser.addEventListener("click", function(e){
    e.preventDefault();
    var email = dcument.getElementById("email".value);
    var password = document.getElementById("password".value);
    createUser(email, password);
    console.log("email" + email + "password" + password);
});

//create a new user based on email and password into auth service
// user will get signed in
//userCredential is an object that gets
function createUser(email, password) {
    console.log("Creating the user");
    createUserWithEmailAndPassword(auth,email,password).then((userCredential)=> {
        //signed in
        const user = userCredential.user;
        console.log("Creating user..." + JSON.stringify(userCredential));
        console.log("User is now signed in"); 
    }).catch((error)=>{
    const errorCode = error.code;
    const errorMessage = error.message;
    console.log(`ErrorCode: ${errorCode} -> Message: ${errorMessage}`);
    });
}
