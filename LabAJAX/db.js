const baseURL = "http://localhost:5000/";
const dbURL = baseURL + "db/";
const tableURL = baseURL + "table/";
const columnURL = baseURL + "column/";
const rowURL = baseURL + "row/";

$("#db-form").submit((e) => {
  e.preventDefault();
  const dbName = $("#db-name").val();
  $.ajax({
    type: "POST",
    url: dbURL,
    data: JSON.stringify({ name: dbName.toString() }),
    success: () => appendCreatingTable(dbName),
    error: (e) => alert(e.responseText),
    contentType: "application/json",
    dataType: "json",
  });
});

function appendCreatingTable(dbName) {
  $("#db-form").remove();
  $("#app").append(`
    <h1>DB: <span id="db">${dbName}</span></h1>
    <form id="table-form">
        <div class="col-auto">
        <label for="table-name">Назва таблиці</label>
        <input
            class="form-control"
            id="table-name"
            placeholder="Введіть назву"
        />
        </div>
        <div class="col-auto">
        <button block type="submit" class="btn btn-secondary w-100 mt-2">
            Створити
        </button>
        </div>
    </form>
    <div id="row-column-form"></div>
    <ul id="table-names" class="list-group list-group-horizontal mt-4">

    </ul>
    `);
  addSubmit();
}

let selectedTable = null;

function addSubmit() {
  const tableURL = "http://localhost:5000/table/";
  $("#table-form").submit((e) => {
    e.preventDefault();
    const dbName = $("#db").text();
    const tableName = $("#table-name").val();
    $.ajax({
      type: "POST",
      url: `${tableURL}${dbName}`,
      data: JSON.stringify({ name: tableName }),
      success: () => onTableCreate(tableName),
      error: (e) => alert(e.responseText),
      contentType: "application/json",
      dataType: "json",
    });
  });
}

function onTableCreate(name) {
  selectedTable = name;
  $("#table-name").val("");
  $("#table-names").append(
    `<li id="${name}" class="list-group-item">${name}</li>`
  );
  $(`#${name}`).on("click", function () {
    selectedTable = name;
    visualize();
  });
  const isFormCreated = $("#row-column-form").children().length;
  if (isFormCreated) return;
  $("#row-column-form").append(`
    <form id="column-form">
      <div class="col-auto">
      <label for="column-name">Назва колонки</label>
      <input
          class="form-control"
          id="column-name"
          placeholder="Введіть назву"
      />
      <select id="column-type" class="form-select">
        <option selected>Оберіть тип</option>
        <option value="Integer">Integer</option>
        <option value="Real">Real</option>
        <option value="Char">Char</option>
        <option value="String">String</option>
        <option value="Time">Time</option>
        <option value="TimeInvl">TimeInvl</option>
      </select>
      </div>
      <div class="col-auto">
      <button block type="submit" class="btn btn-secondary w-100 mt-2">
          Створити
      </button>
      </div>
    </form>
    <button id="create-row-button" block class="btn btn-secondary w-100 mt-2">
        Додати рядок
    </button>
    <form id="join-form">
    <div class="col-auto">
    <label for="table1-name">Table1</label>
    <input
        class="form-control"
        id="table1-name"
        placeholder="Введіть таблицю 1"
    />
    </div>
    <div class="col-auto">
    <label for="table2-name">Table2</label>
    <input
        class="form-control"
        id="table2-name"
        placeholder="Введіть таблицю 2"
    />
    </div>
    <div class="col-auto">
    <button block type="submit" class="btn btn-secondary w-100 mt-2">
        Cartesian
    </button>
    </div>
    </form>

  `);
  addColumnSubmit();
  addRowCreate();
  addCartesianSubmit();
}

function addColumnSubmit() {
  const columnURL = "http://localhost:5000/column/";
  $("#column-form").submit((e) => {
    e.preventDefault();
    const dbName = $("#db").text();

    const name = $("#column-name").val();
    const typename = $("#column-type").val();
    $.ajax({
      type: "POST",
      url: `${columnURL}${dbName}/${selectedTable}`,
      data: JSON.stringify({ name, typename }),
      success: visualize,
      error: (e) => alert(e.responseText),
      contentType: "application/json",
      dataType: "json",
    });
  });
}

function addRowCreate() {
  $("#create-row-button").click(() => {
    const dbName = $("#db").text();
    $.ajax({
      type: "POST",
      url: `${rowURL}${dbName}/${selectedTable}`,
      success: visualize,
      error: (e) => alert(e.responseText),
    });
  });
}

const showTable = (data, dbName) => {
  const columns = data.columnsList
    .map((column) => `<th scope="col">${column.name}(${column.typename})</th>`)
    .join("\n");
  const tableHeaders = `
    <thead>
      <tr>
        ${columns}
      </tr>
    </thead>
  `;

  const getRowValues = (row, rowIndex) =>
    row.values
      .map(
        (value, index) => `
          <td>
            <input value="${value}" id="${rowIndex}-${index}"  class="form-control">
           </td>`
      )
      .join("\n");

  const rows = data.rowsList
    .map((row, index) => `<tr>${getRowValues(row, index)}</tr>`)
    .join("\n");
  const tableBody = `
    <tbody>
      ${rows}
    </tbody>`;

  const table = `
    <table id="table-visual" class="table">
      ${tableHeaders}
      ${tableBody}
    </table>`;
  const tableVisual = $("#table-visual");
  tableVisual && tableVisual.remove();
  $("#app").append(table);

  for (let i = 0; i < data.rowsList.length; i++)
    for (let j = 0; j < data.columnsList.length; j++) {
      $(`#${i}-${j}`).keypress(function (e) {
        if (e.which == 13) {
          const value = $(`#${i}-${j}`).val();
          $.ajax({
            url: `${rowURL}add-value/${dbName}/${selectedTable}/${j}/${i}`,
            data: JSON.stringify({ value }),
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            success: visualize,
            error: (e) => alert(e.responseText),
          });
          return false;
        }
      });
    }
};

function addCartesianSubmit() {
  $("#join-form").submit((e) => {
    e.preventDefault();
    cartesian();
  });
}

function cartesian() {
  const dbName = $("#db").text();
  const table1 = $("#table1-name").val();
  const table2 = $("#table2-name").val();
  $.ajax({
    url: `${tableURL}car/${dbName}/${table1}/${table2}`,
    method: "get",
    dataType: "json",
    success: function (data) {
      showTable(data, dbName);
    },
    error: (e) => alert(e.responseText),
  });
}

function visualize() {
  const dbName = $("#db").text();
  $.ajax({
    url: `${tableURL}${dbName}/${selectedTable}`,
    method: "get",
    dataType: "json",
    success: function (data) {
      showTable(data, dbName);
    },
    error: (e) => alert(e.responseText),
  });
}
