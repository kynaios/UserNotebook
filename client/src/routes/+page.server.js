import axios from 'axios';

export const load = async () => {
	const adultsRes = await fetch('http://localhost:5239/Adult/all');
	const adults = await adultsRes.json();
	const kidsRes = await fetch('http://localhost:5239/Kid/all');
	const kids = await kidsRes.json();

	return {
		adults: adults.map((x) => {
			return {
				...x,
				bagWeight: null,
				schoolName: null
			};
		}),
		kids: kids.map((x) => {
			return {
				...x,
				isEmployed: null,
				companyName: null,
				salary: null
			};
		})
	};
};

export const actions = {
	default: async ({ request }) => {
		const data = await request.formData();

		const id = data.get('id');
		const discriminator = data.get('discriminator');
		const name = data.get('name');
		const surname = data.get('surname');
		const birthDay = data.get('birthDay');
		const sex = Number.parseInt(data.get('sex'));
		const isEmployed = data.get('isEmployed') ? true : false;
		const companyName = isEmployed ? data.get('companyName') : '';
		const salary = isEmployed ? Number.parseInt(data.get('salary')) : 0;
		const schoolName = data.get('schoolName');
		const bagWeight = Number.parseFloat(data.get('bagWeight'));

		const body = {
			id,
			name,
			surname,
			birthDay,
			sex,
			isEmployed,
			companyName,
			salary,
			discriminator,
			schoolName,
			bagWeight
		};

		const req = await axios
			.put(`http://localhost:5239/${discriminator}/update`, body)
			.catch(function (err) {
				console.log(err);
			});
	delete: async ({ request }) => {
		const data = await request.formData();

		const id = data.get('id');
		const discriminator = data.get('discriminator');

		const req = await axios
			.delete(`http://localhost:5239/${discriminator}/${id}`)
			.then((res) => console.log(res))
			.catch(function (err) {
				console.log(err.response.data);
			});
	}
};
