<script>
	import { Label } from '$lib/components/ui/label';
	export let data;

	const { user } = data;
</script>

<div class="grid gap-4 py-4">
	<div class="grid grid-cols-4 items-center gap-4">
		<Label class="text-right">Name</Label>
		<span class="col-span-3">{user.name} </span>
	</div>
	<div class="grid grid-cols-4 items-center gap-4">
		<Label class="text-right">Surname</Label>
		<span class="col-span-3">{user.surname} </span>
	</div>
	<div class="grid grid-cols-4 items-center gap-4">
		<Label class="text-right">Birthday</Label>
		<span class="col-span-3">{user.birthday} </span>
	</div>
	<div class="grid grid-cols-4 items-center gap-4">
		<Label class="text-right">Sex</Label>
		<span class="col-span-3">{user.sex === 0 ? 'Male' : 'Female'} </span>
	</div>
	{#if user.discriminator === 'Adult'}
		<div class="grid grid-cols-4 items-center gap-4">
			<Label
				id="terms-label"
				for="terms"
				class="text-sm justify-self-end font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
			>
				Employed?
			</Label>
			<span class="col-span-3">{user.isEmployed === true ? 'Yes' : 'No'} </span>
		</div>

		{#if user.isEmployed}
			<div class="grid grid-cols-4 items-center gap-4">
				<Label class="text-right">Company Name</Label>
				<span class="col-span-3">{user.companyName} </span>
			</div>
			<div class="grid grid-cols-4 items-center gap-4">
				<Label class="text-right">Salary</Label>
				<span class="col-span-3">{user.salary} </span>
			</div>
		{/if}
	{:else if user.discriminator === 'Kid'}
		<div class="grid grid-cols-4 items-center gap-4">
			<Label class="text-right">School Name</Label>
			<span class="col-span-3">{user.schoolName} </span>
		</div>
		<div class="grid grid-cols-4 items-center gap-4">
			<Label class="text-right">Bag Weight</Label>
			<span class="col-span-3">{user.bagWeight} </span>
		</div>
	{/if}
</div>
