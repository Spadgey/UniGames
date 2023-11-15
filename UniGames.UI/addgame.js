function addGame() {
    console.log("Adding Game function");

    var addGameFormData = {
      gameTitle: document.getElementById('gameTitle').value,
      gameDeveloper: document.getElementById('gameDeveloper').value,
      gameRelease: document.getElementById('gameRelease').value,
      platformId: document.querySelector('input[name="gameplatform"]:checked').value
    }

    console.log(JSON.stringify(addGameFormData));
    fetch('http://localhost:5116/Game', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(addGameFormData)
    })
      .then(response => response.json())
      .then(data => {
        // Handle the response from the server if needed
        console.log(data);
    })
      .catch(error => console.error('Unable to add game.', error));
  }