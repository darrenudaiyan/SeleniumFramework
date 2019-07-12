	function SaveProteinOption(){
		if (typeof(Storage) !== "undefined"){
			var ProteinOptions = document.getElementById('ProteinOptions');
			sessionStorage.setItem('ProteinOption', ProteinOptions.value);
			document.getElementById("SelectedProtein").innerHTML = "Selected: " + sessionStorage.getItem("ProteinOption");
		} 
		else{
			document.getElementById("SelectedProtein").innerHTML = "Sorry, your browser does not support Web Storage...";
		}
	}
	
	function LoadProteinSaveML(){
		GetProtein();
		SaveGetMLOption();
	}
	
	function GetProtein(){
		document.getElementById("SelectedProtein").innerHTML = sessionStorage.getItem("ProteinOption");
	}
	
	function SaveGetMLOption(){
		if (typeof(Storage) !== "undefined"){
			var MLOptions = document.getElementById('MLOptions');
			sessionStorage.setItem('MLOption', MLOptions.value);
			document.getElementById("SelectedML").innerHTML = "Selected: " + sessionStorage.getItem("MLOption");
		} 
		else{
			document.getElementById("SelectedML").innerHTML = "Sorry, your browser does not support Web Storage...";
		}
	}
	
	function GetProteinMLAndData(){
		GetProtein();
		GetML();
		GenerateProteinData();
	}
	
	function GetML(){
		document.getElementById("SelectedML").innerHTML = sessionStorage.getItem("MLOption");
	}
	
	function GenerateProteinData() {
		var table = document.getElementById("ProteinSizerData");
		var head = table.insertRow(0);
		var head1 = head.insertCell(0);
		var head2 = head.insertCell(1);
		var head3 = head.insertCell(2);
		var head4 = head.insertCell(3);
		head1.innerHTML = "Protein";
		head2.innerHTML = "Molecular Weight (KDa)";
		head3.innerHTML = "Protein Length (aa)";
		head4.innerHTML = "Predicted Protein";
		RegenerateData();
	}
	
	function RegenerateData(){
		var table = document.getElementById("ProteinSizerData");
		DeleteData(table);
		for (var i = 1; i <= 12; i++) {
			var row = table.insertRow(i);
			var col1 = row.insertCell(0);
			var col2 = row.insertCell(1);
			var col3 = row.insertCell(2);
			var col4 = row.insertCell(3);
			col1.innerHTML = i;
			col2.innerHTML = GetMWeight(i);
			col3.innerHTML = GetProteinLenght(i);
			col4.innerHTML = GetPredictedProtein(i);
		}
	}
	
	function DeleteData(table){
		for(var i = 1; i < table.rows.length;){   
			table.deleteRow(i);
		}
	}
	
	function GetMWeight(i){
		var molWeight =  64+ (i*Math.random())/10;
		return molWeight.toFixed(3);
	}
	
	function GetProteinLenght(i){
		var proteinLenght = 595 + (i*Math.random())/10;
		return proteinLenght.toFixed(3) ;
	}
	
	function GetPredictedProtein(i){
		var name = (i*Math.random());
		var predictedProtein = "BjNRT1." + name.toFixed(1);
		return predictedProtein;
	}