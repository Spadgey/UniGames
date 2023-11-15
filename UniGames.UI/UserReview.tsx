// JavaScript source code
// Fetch user review data from the server
fetch('http://localhost:5116/game')
    .then(response => response.json())
    .then(data => {
        const UserReviewTableBody = document.querySelector('#UserReviewTable tbody');

        // Loop through the array of games and append them to the table
        data.forEach(UserReview => {
            const row = createTableRow(user);
            UserReviewTableBody.appendChild(row);
        });
    })
    .catch(error => {
        console.error('Error fetching user data:', error);
    });

// Function to create a table row from game data
function createTableRow(User) {
    const row = document.createElement('tr');

    const titleCell = document.createElement('td');
    titleCell.textContent = user.fname;
    row.appendChild(fnameCell);

    const platformCell = document.createElement('td');
    platformCell.textContent = user.lname;
    row.appendChild(lnameCell);

    const scoreCell = document.createElement('td');
    scoreCell.textContent = reveiw.uniGamesScore;
    row.appendChild(reviewCell);

    return row;
} 