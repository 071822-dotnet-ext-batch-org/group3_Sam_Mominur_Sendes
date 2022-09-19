// const subBtn = document.getElementById("subbtn");
// const results = document.getElementById("result");
// const prevGuesses = document.getElementById("numOfPrevGuesses");
// const resultMsg = document.getElementById("resultMsg");
// const enterField = document.getElementById("enter");
// // alert();
// // enterField.value = "";
// enterField.value = "";

// const randomNum = Math.floor(Math.random()*10);
// let turns = 0;

// let getVal = function(){
//     turns++;
//     if((turns > 0) && (turns < 10)){
//         prevGuesses.innerHTML = turns;
//         results.innerHTML += " " +  enterField.value;
//         console.log(subBtn, enterField.value, results, prevGuesses);
//         enterField.focus();
//         if(enterField.value == randomNum){
//             alert("You win!!");
//             resultMsg.innerHTML = `The answer is ${enterField.value}`
//         }
//     }else if(turns == 10){
//         let asn = prompt("\n\t\t\t\tYou did not win. \n\t\t\t\tWant to try again?\n\n\t\t\t\tYes/No").toUpperCase();
//         if(asn == 'YES'){
//             console.log(asn);
//             turns = 0;
//         }else{
//             alert("GAME OVER!!!");
//         }
//     }else{
//         turns =0;
//     }
// }
// subBtn.addEventListener(onclick, getVal());
// // while(true){
// //     break;

// // }


