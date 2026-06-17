function hapusBaris(button) {

    const row = button.closest("tr");
    const tbody = row.parentElement;

    if (tbody.rows.length == 1) {
        alert("Minimal harus ada satu data.");
        return;
    }

    row.remove();

}
////////////////////////////////////////////
function tambahPendidikan() {

    const tbody = document.getElementById("pendidikanBody");

    if (tbody.rows.length >= 4) {
        alert("Maksimal 4 pendidikan.");
        return;
    }

    let i = tbody.rows.length;

    tbody.insertAdjacentHTML("beforeend", `
<tr>

<td>
<input name="PendidikanList[${i}].Jenjang" class="form-control">
</td>

<td>
<input name="PendidikanList[${i}].NamaInstitusi" class="form-control">
</td>

<td>
<input name="PendidikanList[${i}].Jurusan" class="form-control">
</td>

<td>
<input name="PendidikanList[${i}].TahunLulus" type="number" class="form-control">
</td>

<td>
<input name="PendidikanList[${i}].Ipk" type="number" step="0.01" class="form-control">
</td>

<td class="text-center">
<button type="button"
class="btn btn-danger btn-sm"
onclick="hapusBaris(this)">
Hapus
</button>
</td>

</tr>
`);

}

///////////////////////////////////////
function tambahPelatihan() {

    const tbody = document.getElementById("pelatihanBody");

    if (tbody.rows.length >= 4) {

        alert("Maksimal 4 pelatihan.");

        return;
    }

    let i = tbody.rows.length;

    tbody.insertAdjacentHTML("beforeend", `

<tr>

<td>
<input name="PelatihanList[${i}].NamaKursus"
class="form-control">
</td>

<td>

<select name="PelatihanList[${i}].Sertifikat"
class="form-select">

<option value="true">Ada</option>
<option value="false">Tidak</option>

</select>

</td>

<td>

<input name="PelatihanList[${i}].Tahun"
type="number"
class="form-control">

</td>

<td class="text-center">

<button type="button"
class="btn btn-danger btn-sm"
onclick="hapusBaris(this)">

Hapus

</button>

</td>

</tr>

`);

}


/////////////////////////////////////////////

function tambahPekerjaan() {

    const tbody = document.getElementById("pekerjaanBody");

    if (tbody.rows.length >= 4) {

        alert("Maksimal 4 pekerjaan.");

        return;

    }

    let i = tbody.rows.length;

    tbody.insertAdjacentHTML("beforeend", `

<tr>

<td>
<input name="PekerjaanList[${i}].NamaPerusahaan"
class="form-control">
</td>

<td>
<input name="PekerjaanList[${i}].PosisiTerakhir"
class="form-control">
</td>

<td>
<input name="PekerjaanList[${i}].PendapatanTerakhir"
type="number"
class="form-control">
</td>

<td>
<input name="PekerjaanList[${i}].Tahun"
type="number"
class="form-control">
</td>

<td class="text-center">

<button type="button"
class="btn btn-danger btn-sm"
onclick="hapusBaris(this)">

Hapus

</button>

</td>

</tr>

`);

}

/////////////////////////////////


document.addEventListener("DOMContentLoaded", function () {

    const check = document.getElementById("checkSetuju");

    const btn = document.getElementById("btnSimpan");

    if (check) {

        check.addEventListener("change", function () {

            btn.disabled = !this.checked;

        });

    }

});


/////////////////////////////////



