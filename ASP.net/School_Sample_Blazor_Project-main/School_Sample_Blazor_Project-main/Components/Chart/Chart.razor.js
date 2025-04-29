export function chartSetup(id, config) {
    const ctx = document.querySelector(`#${id}`).getContext('2d');
    console.log(config);
    new Chart(ctx, config);
}