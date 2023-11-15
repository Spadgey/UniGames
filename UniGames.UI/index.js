  // Fetch game data from the server
  fetch('http://localhost:5116/Game')
    .then(response => response.json())
    .then(data => {
      const gameTableBody = document.querySelector('#gameTable tbody');

      if(!gameTableBody){return}

      // Loop through the array of games and append them to the table
      data.forEach(game => {
        const row = createTableRow(game);
        gameTableBody.appendChild(row);
      });
    })
    .catch(error => {
      console.error('Error fetching game data:', error);
    });

  // Function to create a table row from game data
  function createTableRow(game) {
    const row = document.createElement('tr');

    const titleCell = document.createElement('td');
    titleCell.textContent = game.title;
    row.appendChild(titleCell);

    const platformCell = document.createElement('td');
    platformCell.textContent = game.platform;
    row.appendChild(platformCell);

    const scoreCell = document.createElement('td');
    scoreCell.textContent = game.uniGamesScore;
    row.appendChild(scoreCell);

    return row;
  }
