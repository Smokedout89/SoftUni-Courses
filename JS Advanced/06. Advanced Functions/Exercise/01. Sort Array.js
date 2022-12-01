function sortArray(arr, type) {
    //return arr.sort((a, b) => type === 'asc' ? a - b : b - a)

    const sorting = {
        asc: (a, b) => a - b,
        desc: (a, b) => b - a
    }

    return arr.sort(sorting[type])
}

sortArray([14, 7, 17, 6, 8], 'asc')
sortArray([14, 7, 17, 6, 8], 'desc')