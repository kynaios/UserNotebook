export const load = async ({ params }) => {
	const { id, discriminator } = params;

	const res = await fetch(`http://localhost:5239/${discriminator}/${id}`);
	const user = await res.json();

	return {
		id,
		discriminator,
		user
	};
};
