document.addEventListener("DOMContentLoaded", function () {
    const tableBody = document.querySelector("#userTable tbody");
    const addButton = document.createElement("button");
    addButton.innerText = "Add New User";
    addButton.className = "btn btn-success mb-3";
    tableBody.parentElement.parentElement.insertBefore(addButton, tableBody.parentElement);

    let users = [];

    function renderUsers() {
        tableBody.innerHTML = "";
        users.forEach((user, index) => {
            const row = document.createElement("tr");

            const nameCell = document.createElement("td");
            nameCell.innerText = user.name;
            row.appendChild(nameCell);

            const cardCell = document.createElement("td");
            cardCell.innerText = user.cardNumber;
            row.appendChild(cardCell);

            const actionCell = document.createElement("td");

            const editBtn = document.createElement("button");
            editBtn.innerText = "Edit";
            editBtn.className = "btn btn-warning me-2";
            editBtn.onclick = () => editUser(index);

            const deleteBtn = document.createElement("button");
            deleteBtn.innerText = "Delete";
            deleteBtn.className = "btn btn-danger";
            deleteBtn.onclick = () => deleteUser(index);

            actionCell.appendChild(editBtn);

            actionCell.appendChild(deleteBtn);
            row.appendChild(actionCell);

            tableBody.appendChild(row);
        });
    }

    function addUser() {
        const name = prompt("Enter user name:");
        const cardNumber = prompt("Enter card number:");
        if (name && cardNumber) {
            users.push({ name: name.trim(), cardNumber: cardNumber.trim() });
            renderUsers();
        }
    }

    function editUser(index) {
        const newName = prompt("Edit user name:", users[index].name);
        const newCard = prompt("Edit card number:", users[index].cardNumber);
        if (newName && newCard) {
            users[index] = { name: newName.trim(), cardNumber: newCard.trim() };
            renderUsers();
        }
    }

    function deleteUser(index) {
        if (confirm("Are you sure you want to delete this user?")) {
            users.splice(index, 1);
            renderUsers();
        }
    }

    addButton.addEventListener("click", addUser);

    renderUsers();
});
document.addEventListener("DOMContentLoaded", function () {
    const addUserBtn = document.getElementById("addUserBtn");
    const table = document.getElementById("userTable");
    const tbody = table.querySelector("tbody");

    addUserBtn.addEventListener("click", function () {
        const name = prompt("أدخل اسم المستخدم:");
        const cardNumber = prompt("أدخل رقم البطاقة:");

        if (name && cardNumber) {
            const row = tbody.insertRow();
            row.innerHTML = `
                <td>${name}</td>
                <td>${cardNumber}</td>
                <td>
                    <button class="btn btn-warning btn-sm">تعديل</button>
                    <button class="btn btn-danger btn-sm">حذف</button>
                </td>
            `;
        }
    });
});
