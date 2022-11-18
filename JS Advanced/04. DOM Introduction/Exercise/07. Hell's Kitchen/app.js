function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let result = [];

   function onClick() {
      let input = JSON.parse(document.getElementById('inputs').children[1].value);
      let bestRestInfo = document.querySelector('#bestRestaurant p');
      let bestRestWorker = document.querySelector('#workers p');

      for (const data of input) {
         let [name, workerList] = data.split(' - ');

         if (!result.find(r => r.name === name)) {
            result.push({
               name,
               avgSalary: 0,
               bestSalary: 0,
               sumSalary: 0,
               workerList: []
            })

         }

         let currentRest = result.find(r => r.name === name);
         workerList = workerList && workerList.split(', ');

         for (const currentWorker of workerList) {
            updateRestaurant(currentRest, currentWorker);
         }
      }

      let bestRest = result.sort((a, b) => b.avgSalary - a.avgSalary)[0];
      bestRestInfo.textContent =
         `Name: ${bestRest.name} Average Salary: ${bestRest.avgSalary.toFixed(2)} Best Salary: ${bestRest.bestSalary.toFixed(2)}`;

      let sortedListOfWorkers = bestRest.workerList.sort((a, b) => b.salary - a.salary);
      let buffer = '';

      for (const worker of sortedListOfWorkers) {
         buffer += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }

      bestRestWorker.textContent += buffer;
   }

   function updateRestaurant(obj, worker) {
      let [name, salary] = worker.split(' ');
      salary = Number(salary);
      obj.sumSalary += salary;

      if (obj.bestSalary < salary) {
         obj.bestSalary = salary;
      }

      obj.workerList.push({
         name,
         salary
      });

      obj.avgSalary = obj.sumSalary / obj.workerList.length;
   }
}