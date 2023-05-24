//4- Encontrar el número más grande en un array de números negativos y positivos

let list = [2,6,-4,7,9,3,6,5,-2,-5,1];

function findBiggest(list){

    let sortedList = list.sort();
    return sortedList[sortedList.length - 1];
}

console.log(findBiggest(list));
