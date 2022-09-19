const otherFile = require('./otherfile'); 
const fs = require('fs-extra');


console.log(`${otherFile.myVar} hello, world!`);

console.log(otherFile.myFunc('sdsd',5));

fs.writeFileSync('./DeepThoughts.txt', 'sjnd.');

// create functions that will 1. write to a new file, 
// 2. append to that new file, then 3. read fgorm that file and 4 .print the content using Node, etc
// 5. use variables and a function that you exprted from another module (file)
// ...using Node, etc