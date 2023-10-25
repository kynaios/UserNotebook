<script lang="ts">
	import { Button } from '$lib/components/ui/button';
	import * as Dialog from '$lib/components/ui/dialog';
	import Delete from './icons/Delete.svelte';

	export let id;
	export let discriminator;
</script>

<Dialog.Root>
	<Dialog.Trigger><Delete /></Dialog.Trigger>
	<Dialog.Content>
		<Dialog.Header>
			<Dialog.Title>Delete user</Dialog.Title>
			<Dialog.Description>Are you sure?</Dialog.Description>
		</Dialog.Header>
		<Dialog.Footer>
			<form method="POST" action="?/delete">
				<input type="hidden" value={id} name="id" />
				<input type="hidden" value={discriminator} name="discriminator" />
				<Button type="submit">Delete user</Button>
			</form>
		</Dialog.Footer>
	</Dialog.Content>
</Dialog.Root>
