<script>
	import { Button } from '$lib/components/ui/button';
	import * as Dialog from '$lib/components/ui/dialog';
	import { Input } from '$lib/components/ui/input';
	import { Label } from '$lib/components/ui/label';

	export let user = {
		id: '',
		name: '',
		surname: '',
		birthDay: '',
		sex: 0,
		isEmployed: false,
		companyName: '',
		salary: 0.0,
		discriminator: 'Adult',
		schoolName: '',
		bagWeight: 0.0
	};
	export let action;

	let isAdult;

	function checkAdult(birthdate) {
		const adulthoodAgeThreshold = 18;

		const today = new Date();
		const birthdayDate = new Date(birthdate);

		const age = today.getFullYear() - birthdayDate.getFullYear();

		if (age > adulthoodAgeThreshold) {
			return true;
		} else if (age === adulthoodAgeThreshold) {
			if (
				today.getMonth() > birthdayDate.getMonth() ||
				(today.getMonth() === birthdayDate.getMonth() && today.getDate() >= birthdayDate.getDate())
			) {
				return true;
			}
		}

		return false;
	}

	$: {
		isAdult = checkAdult(user.birthDay);

		if (isAdult) {
			user.discriminator = 'Adult';
		} else {
			user.discriminator = 'Kid';
		}
	}

	let open = false;
</script>

<Dialog.Root bind:open>
	<Dialog.Trigger><slot /></Dialog.Trigger>
	<Dialog.Content>
		<Dialog.Header>
			<Dialog.Title>{action} User</Dialog.Title>
		</Dialog.Header>
		<form method="POST" action="?/addOrEdit">
			<input type="hidden" bind:value={action} name="action" />
			<input type="hidden" bind:value={user.id} name="id" />
			<input type="hidden" bind:value={user.discriminator} name="discriminator" />
			<div class="grid gap-4 py-4">
				<div class="grid grid-cols-4 items-center gap-4">
					<Label class="text-right">Name</Label>
					<Input id="name" name="name" bind:value={user.name} class="col-span-3" required />
				</div>
				<div class="grid grid-cols-4 items-center gap-4">
					<Label class="text-right">Surname</Label>
					<Input
						id="surname"
						name="surname"
						bind:value={user.surname}
						class="col-span-3"
						required
					/>
				</div>
				<div class="grid grid-cols-4 items-center gap-4">
					<Label class="text-right">Birthday</Label>
					<Input
						id="birthday"
						name="birthDay"
						bind:value={user.birthDay}
						type="date"
						class="col-span-3"
						required
					/>
				</div>
				<div class="grid grid-cols-4 items-center gap-4">
					<Label class="text-right">Sex</Label>
					<select name="sex" id="sex" required>
						<option value={0}>Male</option>
						<option value={1}>Female</option>
					</select>
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
						<input
							type="checkbox"
							id="isEmployed"
							name="isEmployed"
							bind:checked={user.isEmployed}
						/>
					</div>

					{#if user.isEmployed}
						<div class="grid grid-cols-4 items-center gap-4">
							<Label class="text-right">Company Name</Label>
							<Input
								id="companyName"
								name="companyName"
								value={user.companyName}
								class="col-span-3"
							/>
						</div>
						<div class="grid grid-cols-4 items-center gap-4">
							<Label class="text-right">Salary</Label>
							<Input
								id="salary"
								name="salary"
								value={user.salary}
								type="number"
								class="col-span-3"
							/>
						</div>
					{/if}
				{:else if user.discriminator === 'Kid'}
					<div class="grid grid-cols-4 items-center gap-4">
						<Label class="text-right">School Name</Label>
						<Input id="schoolName" name="schoolName" value={user.schoolName} class="col-span-3" />
					</div>
					<div class="grid grid-cols-4 items-center gap-4">
						<Label class="text-right">Bag Weight</Label>
						<Input
							id="bagWeight"
							name="bagWeight"
							value={user.bagWeight}
							type="number"
							step="0.1"
							min="0"
							max="10"
							class="col-span-3"
						/>
					</div>
				{/if}
			</div>
			<Dialog.Footer>
				<Button type="submit">{action} User</Button>
			</Dialog.Footer>
		</form>
	</Dialog.Content>
</Dialog.Root>
