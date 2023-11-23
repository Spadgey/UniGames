// Fetch game userReview from the server
fetch('http://localhost:5116/game')
    .then(response => response.json())
    .then(data => {
        const UserReviewTableBody = document.querySelector('#userreviewTable tbody');

        // Loop through the array of games and append them to the table
        data.forEach(user => {
            const row = createTableRow(user);
            UserReviewTableBody.appendChild(row);
        });
    })
    .catch(error => {
        console.error('Error fetching userreview data:', error);
    });

// Function to create a table row from game data
function createTableRow(user) {
    const row = document.createElement('tr');

    const titleCell = document.createElement('td');
    titleCell.textContent = user.fname;
    row.appendChild(fnameCell);

    const platformCell = document.createElement('td');
    platformCell.textContent = user.lname;
    row.appendChild(lnameCell);

    const scoreCell = document.createElement('td');
    scoreCell.textContent = game.review;
    row.appendChild(reviewCell);


    return row;
} 
function myFunction() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("ReviewTable");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}