//7- Obtener el promedio de las edades de los usuarios mayores de edad

let ageList = [15, 17, 18, 19, 20, 16, 17, 19, 20, 20, 18];

function checkAge(age){
    if (age < 18){
        return false;
    } else{
        return true;
    }
}

function ageMean(ageList){

    let sum = 0;
    sorted = ageList.sort();
    for (i = 0; i < sorted.length; i++){
        sorted.forEach(age => {
            if(!checkAge(age)){
                sorted.shift();
            }
        });
    }

    for (i = 0; i < sorted.length; i++){
        sum += sorted[i];
    }

    return sorted + " " + sum/sorted.length;
}

console.log(ageMean(ageList));