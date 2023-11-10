const audio = document.getElementById('audio');
const playPauseButton = document.getElementById('play-pause');
const volumeSlider = document.getElementById('volume');
const currentTime = document.getElementById('current-time');
const duration = document.getElementById('duration');

playPauseButton.addEventListener('click', function () {
    if (audio.paused) {
        audio.play();
        playPauseButton.textContent = 'Pause';
        playPauseButton.classList.remove('play');
    } else {
        audio.pause();
        playPauseButton.textContent = 'Play';
        playPauseButton.classList.add('play');
    }
});

volumeSlider.addEventListener('input', function () {
    audio.volume = volumeSlider.value;
});

audio.addEventListener('play', function () {
    playPauseButton.textContent = 'Pause';
    playPauseButton.classList.remove('play');
});

audio.addEventListener('pause', function () {
    playPauseButton.textContent = 'Play';
    playPauseButton.classList.add('play');
});

audio.addEventListener('timeupdate', function () {
    const currentMinutes = Math.floor(audio.currentTime / 60);
    const currentSeconds = Math.floor(audio.currentTime % 60);
    const durationMinutes = Math.floor(audio.duration / 60);
    const durationSeconds = Math.floor(audio.duration % 60);

    currentTime.textContent = `${currentMinutes}:
    ${currentSeconds < 10 ? '0' : ''}${currentSeconds}`;
    duration.textContent = `${durationMinutes}:${durationSeconds}`;
});

