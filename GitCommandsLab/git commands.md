# 🚀 Git Rebase (atualizar minha branch)

git checkout minha-branch
git fetch origin
git rebase origin/main


# 🧠 Git Rebase Interativo
git rebase -i HEAD~3

Comandos úteis:
pick: manter
reword: mudar mensagem
squash: juntar com o anterior
drop: remover o commit

# 🧽 Desfazer rebase
git rebase --abort

# 💥 Resolver conflitos no rebase

git status
git add .
git rebase --continue

# Comentários