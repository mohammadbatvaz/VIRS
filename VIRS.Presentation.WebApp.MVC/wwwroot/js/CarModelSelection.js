const dataDiv = document.getElementById("carModelsData");
const carModels = JSON.parse(dataDiv.getAttribute("data-car-models"));

const manufacturerSelect = document.getElementById("manufacturer");
const familySelect = document.getElementById("family");
const modelSelect = document.getElementById("model");

const hiddenMan = document.getElementById("selectedManufacturer");
const hiddenFam = document.getElementById("selectedFamily");
const hiddenModel = document.getElementById("selectedModelName");

const manufacturers = [...new Set(carModels.map(x => x.manufacturer))];

manufacturers.forEach(m => {
    manufacturerSelect.innerHTML += `<option value="${m}">${m}</option>`;
});

manufacturerSelect.addEventListener("change", () => {
    hiddenMan.value = manufacturerSelect.value;

    familySelect.innerHTML = `<option value="">انتخاب خانواده...</option>`;
    familySelect.disabled = !manufacturerSelect.value;

    modelSelect.innerHTML = `<option value="">ابتدا خانواده را انتخاب کنید</option>`;
    modelSelect.disabled = true;

    const families = [...new Set(
        carModels.filter(x => x.manufacturer === manufacturerSelect.value)
            .map(x => x.family)
    )];

    families.forEach(f => {
        familySelect.innerHTML += `<option value="${f}">${f}</option>`;
    });

    hiddenFam.value = "";
    hiddenModel.value = "";
});

familySelect.addEventListener("change", () => {
    hiddenFam.value = familySelect.value;

    modelSelect.innerHTML = `<option value="">انتخاب مدل...</option>`;
    modelSelect.disabled = !familySelect.value;

    const filteredModels = carModels.filter(x =>
        x.manufacturer === manufacturerSelect.value &&
        x.family === familySelect.value
    );

    filteredModels.forEach(m => {
        modelSelect.innerHTML += `<option value="${m.name}">${m.name}</option>`;
    });

    hiddenModel.value = "";
});

modelSelect.addEventListener("change", () => {
    hiddenModel.value = modelSelect.value;
});
