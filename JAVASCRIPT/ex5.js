//5- Crea una función que tome una cadena de palabras separadas por espacios y devuelva la palabra más larga.

let sentence = "This is a sample sentence";

function longestWord(sentence){
    wordArray = sentence.split(" ");
    
    sortedArray = wordArray.sort((a, b) => (b.length - a.length));
    
    return sortedArray[0];
}

console.log(longestWord(sentence));