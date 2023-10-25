<script>
	import * as Table from '$lib/components/ui/table';
	import Check from '../components/icons/Check.svelte';
	import Delete from '../components/icons/Delete.svelte';
	import AddOrEditDialog from '../components/AddOrEditDialog.svelte';
	import View from '../components/icons/View.svelte';
	import DeleteDialog from '../components/DeleteDialog.svelte';
	import Edit from '../components/icons/Edit.svelte';
	import UserAdd from '../components/icons/UserAdd.svelte';

	export let data;

	const users = [...data.adults, ...data.kids];
</script>

<AddOrEditDialog action="Create">
	<UserAdd />
</AddOrEditDialog>
<Table.Root>
	<Table.Caption>User Notebook</Table.Caption>
	<Table.Header>
		<Table.Row>
			<Table.Head>Name</Table.Head>
			<Table.Head>Surname</Table.Head>
			<Table.Head>Birthday</Table.Head>
			<Table.Head>Sex</Table.Head>
			<Table.Head>Bag Weight</Table.Head>
			<Table.Head>Company Name</Table.Head>
			<Table.Head>Is Employed</Table.Head>
			<Table.Head>Salary</Table.Head>
			<Table.Head>School Name</Table.Head>
			<Table.Head>Actions</Table.Head>
		</Table.Row>
	</Table.Header>
	<Table.Body>
		{#each users as user}
			<Table.Row>
				<Table.Cell>{user.name}</Table.Cell>
				<Table.Cell>{user.surname}</Table.Cell>
				<Table.Cell>{user.birthDay}</Table.Cell>
				{#if user.sex === 0}
					<Table.Cell>Male</Table.Cell>
				{:else}
					<Table.Cell>Female</Table.Cell>
				{/if}
				{#if user.bagWeight !== null}
					<Table.Cell>{user.bagWeight}</Table.Cell>
				{:else}
					<Table.Cell />
				{/if}

				{#if user.companyName !== null}
					<Table.Cell>{user.companyName}</Table.Cell>
				{:else}
					<Table.Cell />
				{/if}

				{#if user.isEmployed}
					<Table.Cell><Check /></Table.Cell>
				{:else}
					<Table.Cell />
				{/if}

				{#if user.salary !== null}
					<Table.Cell>{user.salary}</Table.Cell>
				{:else}
					<Table.Cell />
				{/if}

				{#if user.schoolName !== null}
					<Table.Cell>{user.schoolName}</Table.Cell>
				{:else}
					<Table.Cell />
				{/if}
				<Table.Cell class="flex gap-4">
					<a href={`/${user.discriminator}/${user.id}`}><View /></a>
					<AddOrEditDialog bind:user action="Update">
						<Edit />
					</AddOrEditDialog>
					<DeleteDialog id={user.id} discriminator={user.discriminator} name="id" />
				</Table.Cell>
			</Table.Row>
		{/each}
	</Table.Body>
</Table.Root>
