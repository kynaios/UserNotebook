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
