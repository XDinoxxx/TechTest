const apiBase = "/api/Auth";

const messageEl = document.getElementById("message");

function showMessage(msg, success = true) {
    messageEl.textContent = msg;
    messageEl.className = success ? "text-success mt-3 fw-semibold" : "text-danger mt-3 fw-semibold";
}

document.getElementById("login").addEventListener("submit", async (e) => {
    e.preventDefault();

    const username = document.getElementById("loginUsername").value;
    const password = document.getElementById("loginPassword").value;

    try {
        const response = await fetch(`${apiBase}/login`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ username, password }),
        });

        const data = await response.json();

        console.log(data)

        if (data.ResultCode === -1) 
            showMessage("❌ Login failed ", false);
        else 
            showMessage(`✅ Login successful! EntityID - ${data.EntityId}, FirstName - ${data.FirstName}, LastName - ${data.LastName}`);
    } catch (err) {
        showMessage("⚠️ Network error: " + err.message, false);
    }
});