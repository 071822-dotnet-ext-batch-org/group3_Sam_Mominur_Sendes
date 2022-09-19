// "use strict;"

// const xhr = new XMLHttpRequest();
// console.log(`The readystate is ${xhr.readystate}`);


// xhr.onreadystatechange = () => {
//   console.log(`The readystate is ${xhr.readyState} - \nThe status code is ${xhr.status}`)
//   if (xhr.readyState == 4 && xhr.status == 200) {
//     console.log(`The responsetype is ${xhr.responseType.valueOf}.`);
//     console.log(`The responsetext is ${xhr.responseText}`);
//     displyResponseTextInBrowser();
//   }
//   else {
//     console.log(`Jokes are not ready yet!`);
//   }
// };

// xhr.open('GET', 'http://api.icndb.com/jokes/random', true);
// xhr.send();

// // I want a div that I can put p elements 
// // into to display the joke text
// function displyResponseTextInBrowser() {
//   //get the body object
//   let bodie = document.body;
//   //create the div
//   let myDiv = document.createElement('div');
//   //create the p element
//   let myP = document.createElement('p');
//   //add the div and p to the html
//   myDiv.appendChild(myP);
//   bodie.appendChild(myDiv)
//   //convert the JSON string into a JS object
//   let resText = JSON.parse(xhr.responseText);
//   console.log(resText)
//   //add the text to the p element
//   myP.textContent = resText.value.joke;

// }

// // now get 5 Jokes
// const xhr2 = new XMLHttpRequest();
// console.log(`The readystate is ${xhr2.readystate}`);
// xhr2.onreadystatechange = () => {
//   if (xhr2.readyState == 4 && xhr2.status == 200) {
//     displyJokesInBrowser();
//   }
//   else {
//     console.log(`Jokes are not ready yet!`);
//   }
// };
// let five = 5;

// xhr2.open('GET', `http://api.icndb.com/jokes/random/${five}`, true);
// xhr2.send();

// function displyJokesInBrowser() {

//   console.log(xhr2.responseText);
//   //get the new div element
//   // let myDiv = document.querySelector('div');
//   //convert the JSON string into a JS object
//   // let resText = JSON.parse(xhr.responseText);
//   //console.log(resText)
//   // myDiv.appendChild();


// }


//---------------------------------------Group3 Section -----------


// "Use Strict;"

// const xhr2 = new XMLHttpRequest();



// console.log(`The readystate is ${xhr2.readyState}`);

// xhr2.onreadystatechange = () =>{
//     console.log(`The readystate is ${xhr2.readyState}\nCurrent Status: ${xhr2.status}`);
//     if(xhr2.readyState == 4 && xhr2.status == 200){
//         console.log(`The responseType is ${xhr2.statusText}`);
//         console.log(`The responseText is ${xhr2.responseText}`);
//         displayResponseonForm();
//     }else{
//         console.log(`The jokes havent been gotten yet`);

//     }
// }

// xhr2.open(`GET`, `http://api.icndb.com/jokes/random/${Math.floor(Math.random()*6)}`, true);
// xhr2.send();

// function displayResponseonForm(){
//     let bodie = document.body;

//     let myDiv = document.createElement('div');
    
    
//     bodie.appendChild(myDiv);
    
//     let response = JSON.parse(xhr2.responseText) ;
//     console.log(response);
//     let count=1;
//     for (const x of response.value) {
//         //Moving the p tag created into for loop 
//         //creates a new p tag each loop
//         let myP = document.createElement('p');
//         myDiv.appendChild(myP);
//         // code block to be executed
//         myP.textContent += `\n` + `${count++}` + ` ` + `${x.joke}`  ;//response;

//       }

//     //JSON.parse converts json text to json

// }


//Fetching beloww
// fetch(`https://localhost:7029/api/UserAuth/Login/user%40EMAIL.COM/Pass1`)
//     .then(
//         (res) => {
//             console.log(`The User ID - ${res.PK_UserID}`);
//             return res.json();
//         },
//         (res) => {throw new Error("\n THere was an error\n")}
//     )
//     .then((body) => {
//         for(let x of body){
//             console.log(`${x.PK_UserID}\n
//             ${x.UserName}`)
//         }
//     })
//     .catch(err => {throw new Error(`\nThere was a new error\n`)})


// fetch('https://localhost:7029/api/Products', {
//     method: 'POST', 
//     headers: {'Content-Type': 'application/json'},
//     body: JSON.stringify(
//         {
//             "Title": "FrontEndProd1",
//             "Description": "Desc1",
//             "Price": "30",
//             "Inventory": "5",
//             "User": "user@EMAIL.COM",
//         }
//     )
//     .then(
//         res => {
//             if(res.ok){
//                 return res.JSON();
//             }
//         }
//     )
//     .then(
//         bodie => {
//             console.log(bodie.PK_ProductID)
//         }
//     )
// })

// fetch('https://localhost:7029/api/Products/Products')
// .then(
//     (response) => {
//         console.log(response.ok, response.status, response.type, response.headers);
//         return response.json;
//     },
//     (response) => {
//         console.log(response.ok, response.status, response.type, response.headers);
//         throw new Error("Theres was an error retreiving that data DOG!");
//     }
// )