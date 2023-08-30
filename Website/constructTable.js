function ConstructTable(name, ColumnNumber=1) {
	const table = document.getElementById(name);

	fetch("data.json")
	  .then(value => value.json())
	  .then(list => {
		
		let cols = [];
		for (let i = 0; i < list.length; i++) {
			for (let k in list[i]) {
				if (cols.indexOf(k) === -1) { //Prevents duplication somehow
					cols.push(k);
				}
			}
		}
			
		for (let i = 0; i < list.length; i++) { // Adding the data to the table
			trow = table.insertRow(-1); // Create a new row
			for (let j = 0; j < cols.length; j++) {
				let cell = trow.insertCell(-1);
				cell.innerHTML = list[i][cols[j]]; // Inserting the cell at particular place
			}
		}
		sortTable(name, ColumnNumber);
	});
}