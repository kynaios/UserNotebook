export const load = async ({ params }) => {
	const { id, discriminator } = params;

	const res = await fetch(`http://server/${discriminator}/${id}`);
	const user = await res.json();

	return {
		id,
		discriminator,
		user
	};
};
