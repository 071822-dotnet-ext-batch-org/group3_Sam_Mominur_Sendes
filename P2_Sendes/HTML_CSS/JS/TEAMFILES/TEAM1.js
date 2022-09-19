const baseFile = require('./TEAM_BASE.js');
const fs = require('fs-extra');
const file = './TeamFile.txt';
const teamText = baseFile.teamFunc('Group3', 'Ecom Store', '1');
const teamAddedText = baseFile.teamFunc2(teamText, baseFile.teamFunc.name)
// console.log(`This file will say ${teamText}`);

fs.writeFileSync(file, teamText);

fs.appendFileSync(file,teamAddedText );

const read = fs.readFileSync(file);
console.log(read);