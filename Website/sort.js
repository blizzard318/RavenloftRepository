function colorCode(tableName) {
  let flipflop = true;
  const rows = document.getElementById(tableName).rows;
  for (var i = 1; i < rows.length; i++) {
	if (rows[i].style.display == "none") continue;
    rows[i].style.background = flipflop ? "#323232" : "#626262";
	flipflop = !flipflop;
  }
}

function sortDate (tableName, n) {
	function convertDate(d) {
	  const p = d.split("/");
	  return +(p[2]+p[1]+p[0]);
	}
  let shouldSwitch, switching, switchcount = 0, dir = "asc";
  const rows = document.getElementById(tableName).rows;
  /* Make a loop that will continue until
  no switching has been done: */
  do {
    // Start by saying: no switching is done:
    switching = false;
    /* Loop through all table rows (except the
    first, which contains table headers): */
    for (var i = 1; i < (rows.length - 1); i++) {
      // Start by saying there should be no switching:
      shouldSwitch = false;
      /* Get the two elements you want to compare,
      one from current row and one from the next: */
      const x = convertDate(rows[i].getElementsByTagName("TD")[n]);
      const y = convertDate(rows[i + 1].getElementsByTagName("TD")[n]);
      /* Check if the two rows should switch place,
      based on the direction, asc or desc: */
      if (dir == "asc") {
        if (x > y) {
          // If so, mark as a switch and break the loop:
          shouldSwitch = true;
          break;
        }
      } else if (dir == "desc") {
        if (x < y) {
          // If so, mark as a switch and break the loop:
          shouldSwitch = true;
          break;
        }
      }
    }
    if (shouldSwitch) {
      /* If a switch has been marked, make the switch
      and mark that a switch has been done: */
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
      // Each time a switch is done, increase this count by 1:
      switchcount ++;
    } else {
      /* If no switching has been done AND the direction is "asc",
      set the direction to "desc" and run the while loop again. */
      if (switchcount == 0 && dir == "asc") {
        dir = "desc";
        switching = true;
      }
    }
  } while (switching);

  colorCode(table);
}

function sortDate (tableName, n) {
  // Set the sorting direction to ascending:
  let shouldSwitch, switching, switchcount = 0, dir = "asc";
  const rows = document.getElementById(tableName).rows;
  /* Make a loop that will continue until
  no switching has been done: */
  do {
    // Start by saying: no switching is done:
    switching = false;
    /* Loop through all table rows (except the
    first, which contains table headers): */
    for (var i = 1; i < (rows.length - 1); i++) {
      // Start by saying there should be no switching:
      shouldSwitch = false;
      /* Get the two elements you want to compare,
      one from current row and one from the next: */
      const x = rows[i].getElementsByTagName("TD")[n];
      const y = rows[i + 1].getElementsByTagName("TD")[n];
      /* Check if the two rows should switch place,
      based on the direction, asc or desc: */
      if (dir == "asc") {
        if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
          // If so, mark as a switch and break the loop:
          shouldSwitch = true;
          break;
        }
      } else if (dir == "desc") {
        if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
          // If so, mark as a switch and break the loop:
          shouldSwitch = true;
          break;
        }
      }
    }
    if (shouldSwitch) {
      /* If a switch has been marked, make the switch
      and mark that a switch has been done: */
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
      // Each time a switch is done, increase this count by 1:
      switchcount ++;
    } else {
      /* If no switching has been done AND the direction is "asc",
      set the direction to "desc" and run the while loop again. */
      if (switchcount == 0 && dir == "asc") {
        dir = "desc";
        switching = true;
      }
    }
  } while (switching);

  colorCode(table);
}