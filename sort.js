function sortDate(tableName, n) {
    var convert = (row) => {
        const p = row.getElementsByTagName('td')[n].innerText.split('/');
        if (isNaN(Number(p[2] + p[1] + p[0]))) console.log(row.getElementsByTagName('td')[n].innerText);
        return Number(p[2] + p[1] + p[0]);
    }
    sortTableBy(tableName, convert);
}

function sortTable(tableName, n) {
    var convert = (row) => row.getElementsByTagName('td')[n].innerHTML.toLowerCase();
    sortTableBy(tableName, convert);
}

function colorCode(table) {
    let flipflop = true;
    const rows = table.rows;
    for (var i = 1; i < rows.length; i++) {
        if (rows[i].style.display == 'none') continue;
        rows[i].style.background = flipflop ? 'var(--row1)' : 'var(--row2)';
        flipflop = !flipflop;
    }
}

function sortTableBy(tableName, convert) {
    // Set the sorting direction to ascending:
    let shouldSwitch, switching, switchcount = 0,
        dir = 'asc';
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
            const x = convert(rows[i]);
            const y = convert(rows[i + 1]);
            /* Check if the two rows should switch place,
            based on the direction, asc or desc: */
            if (dir == 'asc') {
                if (x > y) {
                    // If so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == 'desc') {
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
            switchcount++;
        } else {
            /* If no switching has been done AND the direction is "asc",
            set the direction to "desc" and run the while loop again. */
            if (switchcount == 0 && dir == 'asc') {
                dir = 'desc';
                switching = true;
            }
        }
    } while (switching);

    colorCode(document.getElementById(tableName));
}

function OpenPage(pageName) {
    var pages = document.getElementsByClassName('page');
    for (page of pages) page.style.display = 'none';
    document.getElementById(pageName).style.display = 'block';
}

function init() {
    if (!sessionStorage.getItem('darkmode') && window.matchMedia && window.matchMedia('(prefers-color-scheme:dark)').matches)
        sessionStorage.setItem('darkmode', true);

    SetDarkMode(sessionStorage.getItem('darkmode') === 'true');
    document.getElementById('darkmode').checked = (sessionStorage.getItem('darkmode') === 'true');
    document.getElementById('darkmode').addEventListener('change', () => SetDarkMode(document.getElementById('darkmode').checked));

    function SetDarkMode(setval) {
        if (setval) document.querySelector('html').dataset.darkmode = true;
        else delete document.querySelector('html').dataset.darkmode;

        sessionStorage.setItem('darkmode', setval);
    }

    const tables = document.querySelectorAll('table');
    tables.forEach(table => colorCode(table));
}