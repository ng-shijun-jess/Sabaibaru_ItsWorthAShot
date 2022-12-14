import { initializeApp } from "https://www.gstatic.com/firebasejs/9.15.0/firebase-app.js";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

import {
  ref, child, get, getDatabase, set
} from "https://www.gstatic.com/firebasejs/9.15.0/firebase-database.js";


// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyD04Qf12qgRAf7Joburgt5v4UJwEitY0fk",
  authDomain: "its-worth-a-shot.firebaseapp.com",
  databaseURL: "https://its-worth-a-shot-default-rtdb.asia-southeast1.firebasedatabase.app",
  projectId: "its-worth-a-shot",
  storageBucket: "its-worth-a-shot.appspot.com",
  messagingSenderId: "613566342054",
  appId: "1:613566342054:web:fea46a561de70eaf342567"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

// Initialize Realtime Database and get a reference to the service
const db = getDatabase(app);

const playerRef = ref(db, "players");
getPlayerData();
function getPlayerData() {
  //const playerRef = ref(db, "players");
  //PlayerRef is declared at the top using a constant
  //get(child(db,`players/`))
  get(playerRef)
    .then((snapshot) => {//retrieve a snapshot of the data using a callback
      if (snapshot.exists()) {//if the data exist
        try {
          //let's do something about it
          var playerStats = document.getElementById("player-stats");
          var stats = "";
          snapshot.forEach((childSnapshot) => {
            //looping through each snapshot
            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach
            console.log("User key: " + childSnapshot.key);
            console.log("Username: " + childSnapshot.child("userName").val());
            console.log("GetPlayerData: childkey " + childSnapshot.key);
            console.log("Email: " + childSnapshot.child("email").val());
            console.log("Created On: " + childSnapshot.child("createdOn").val());
            console.log("Last Logged In: " + childSnapshot.child("lastLoggedIn").val());
            document.getElementById("displayName").innerHTML = childSnapshot.child("userName").val();
            document.getElementById("displayEmail").innerHTML = childSnapshot.child("email").val();
            document.getElementById("displayCreatedOn").innerHTML = childSnapshot.child("createdOn").val();
            document.getElementById("displayLoggedIn").innerHTML = childSnapshot.child("lastLoggedIn").val();
            document.getElementById("displayStatus").innerHTML = childSnapshot.child("active").val();
            if (document.getElementById("displayStatus").innerHTML == "true")
            {
              console.log("User is active");
              document.getElementById("displayStatus").innerHTML = "Active";
            }
            else
            {
              console.log("User is inactive");
              document.getElementById("displayStatus").innerHTML = "Offline";
            };

            stats += `<tr>
                    <td>${childSnapshot.child("active").val()}</td>
                    //======= insert your own place to update UI
                    </tr>`;
          });
          //update our table content
          playerStats.innerHTML = stats;
        } catch (error) {
          console.log("Error getPlayerData" + error);
        }
      }
      else {
        console.log("No data available");
      }
    });
}//end getPlayerData

function writePlayerData(userId, username, email, createdOn, loggedOn, active){
  const db = getDatabase
  set(ref(db, 'players' + userId), {
    username : username,
    email: email,
    createdOn: createdOn,
    loggedOn: loggedOn,
    active: active
  })
}